require 'kafka'
class PlayMachineConsumer
  def perform
    kafka = Kafka.new(['82.179.84.219:9001'])
    consumer = kafka.consumer(group_id: '123')
    consumer.subscribe('bosh-play-machine', start_from_beginning: false)
    consumer.each_message do |message|
      create_signal_values(message)
    end
  end

  def create_signal_values(message)
    raw_signal_batch = JSON.parse(message.value)
    offset = message.offset
    moment = raw_signal_batch.delete('moment')
    raw_signal_batch.map do |raw_signal|
      create_signal_value_service = CreateSignalValueService.new.call(raw_signal, raw_signal_batch, moment, offset)
      logger.error(create_signal_value_service.failure) if create_signal_value_service.failure?
    end
  end

  def logger
    @logger ||= Logger.new('log/import_test_batch_signals_log.log')
  end
end
