require 'dry/monads'
require 'csv'

class CreateSignalValueService
  include Dry::Monads[:result, :do]
  attr_reader :rows

  def call(raw_signal, raw_signal_batch, moment, offset)
    signal_kind = yield find_signal_kind(raw_signal[0])
    setpoints = find_setpoints_if_exist(signal_kind, raw_signal_batch)
    return Success('skip setpoints') if signal_kind.setpoint?

    signal_value = SignalValue.create(
      value: raw_signal[1],
      signal_kind: signal_kind,
      batch_time: moment,
      offset: offset,
      **setpoints
    )

    signal_value.set_status!
    signal_kind.aspirator.update_column('last_offset', offset)
    if signal_value.valid?
      create_issue_request_if_need(signal_value)
      Success(signal_value)
    else
      Failure(signal_value.errors.messages)
    end
  end

  def create_issue_request_if_need(signal_value)
    return unless signal_value.status != :ok
    return if IssueRequest.includes(:signal_value).where(
      state: :open,
      signal_value: { signal_kind_id: signal_value&.signal_kind_id }
    ).any?

    IssueRequest.create(
      signal_value: signal_value,
      state: :open
    )
  end

  def find_signal_kind(kafka_code)
    return Failure("Kafka code don't present") if kafka_code.blank?

    signal_kind = SignalKind.find_by_kafka_code(kafka_code)
    return Failure("can't find signal kind by code #{kafka_code}") if signal_kind.blank?

    Success(signal_kind)
  end

  def find_setpoints_if_exist(signal_kind, raw_signal_batch)
    r = SignalKind.where(
      device_kind_id: signal_kind.device_kind_id,
      aspirator_id: signal_kind.aspirator_id,
      value_kind_id: signal_kind.value_kind_id,
      controlled_parameter_id: signal_kind.controlled_parameter_id
    ).setpoints.map do |setpoint|
      { setpoint.code => raw_signal_batch[setpoint.kafka_code] }
    end.reduce(&:merge) || {}
    r[:warning_max] ||= signal_kind.warning_max
    r[:warning_min] ||= signal_kind.warning_min
    r[:alarm_max] ||= signal_kind.alarm_max
    r[:alarm_min] ||= signal_kind.alarm_min
    r
  end

  def logger
    @logger ||= Logger.new('log/import_batch_signals_log.log')
  end
end
