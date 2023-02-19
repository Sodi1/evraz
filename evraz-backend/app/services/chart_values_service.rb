require 'dry/monads'
require 'csv'

class ChartValuesService
  include Dry::Monads[:result, :do]
  attr_reader :rows

  def call(signal_kind_ids, start_time, end_time, include_setpoints)
    return Failure('signal_kind_ids is not array') unless signal_kind_ids.is_a? Array
    return Failure('Invalid signal kinds') if signal_kind_ids.empty?

    start_time = begin
      Time.parse(start_time)
    rescue ArgumentError => e
      return Failure(e.message)
    end
    end_time = begin
      Time.parse(end_time)
    rescue ArgumentError => e
      return Failure(e.message)
    end
    signal_values_grouped_by_signal_kind = SignalValue.order(offset: :asc).includes(:signal_kind).where(batch_time: start_time..end_time,
                                                                                    signal_kind_id: signal_kind_ids
                                                                                   ).group_by do |sv|
      sv.signal_kind
    end
    chart_data = signal_values_grouped_by_signal_kind.map do |signal_kind, signal_values|
      if include_setpoints
        #alarm_max warning_max alarm_min warning_min
        { signal_kind.id => signal_values.map { |sv| [sv.batch_time, sv.value, sv.warning_min, sv.warning_max, sv.alarm_min, sv.alarm_max] } }
      else
        { signal_kind.id => signal_values.map { |sv| [sv.batch_time, sv.value] } }
      end
    end
    Success(chart_data)
  end
end