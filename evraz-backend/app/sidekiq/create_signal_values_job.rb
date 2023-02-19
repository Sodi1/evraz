class CreateSignalValuesJob
  include Sidekiq::Job

  def perform(evraz_kafka_datum_id)
    ImportBatchSignalsService.new.call(evraz_kafka_datum_id)
  end
end