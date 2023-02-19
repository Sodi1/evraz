class UpdateTimeJob
  include Sidekiq::Job

  def perform(first_id, last_id)
    SignalValue.includes(:evraz_kafka_datum).where(
      id: first_id..last_id
    ).each do |sv|
      sv.update_column('batch_time', sv.evraz_kafka_datum.payload['moment'].in_time_zone('UTC'))
    rescue StandardError
      nil
    end
  end
end
