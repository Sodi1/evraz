class BoshPlayMachineConsumerJob
  include Sidekiq::Job

  def perform
    PlayMachineConsumer.new.perform
  end
end
