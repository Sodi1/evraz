require 'dry/monads'
require 'csv'

class ImportBatchSignalsService
  include Dry::Monads[:result, :do]
  attr_reader :rows

  def call(evraz_kafka_datum_id = nil)
    evraz_kafka_datum = EvrazKafkaDatum.find(evraz_kafka_datum_id)
    raw_signal_batch = evraz_kafka_datum.payload
    offset = evraz_kafka_datum.offset
    moment = raw_signal_batch.delete('moment')
    moment = moment&.in_time_zone('UTC')
    raw_signal_batch.map do |raw_signal|
      create_signal_value_service = CreateSignalValueService.new.call(raw_signal, raw_signal_batch, moment, offset)
      logger.error(create_signal_value_service.failure) if create_signal_value_service.failure?
    end
    Success('Signals created')
  end

  def logger
    @logger ||= Logger.new('log/import_batch_signals_log.log')
  end
end
