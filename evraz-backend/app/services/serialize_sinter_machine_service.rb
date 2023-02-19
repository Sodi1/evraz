require 'dry/monads'

class SerializeSinterMachineService
  include Dry::Monads[:result, :do]
  def call(sinter_machine, time_machine_offset = nil)
    serialized_aspirators_sevices = sinter_machine.aspirators.map { |aspirator| SerializeAspiratorService.new.call(aspirator, time_machine_offset) }
    return Failure(serialized_aspirators_sevices.map(&:failure)) if serialized_aspirators_sevices.any?(&:failure?)

    serialized_aspirators_sevices = serialized_aspirators_sevices.select(&:success?)
    serialized_aspirators = serialized_aspirators_sevices.map(&:success)
    status = define_status(serialized_aspirators)
    serialized_sinter_machine = SinterMachine::ShowSerializer.new(sinter_machine, aspirators: serialized_aspirators, status: status)
    Success(serialized_sinter_machine)
  end

  def define_status(serialized_aspirators)
    statuses = serialized_aspirators.map { |sa| sa[:status] }
    if statuses.include? :alarm
      :alarm
    elsif statuses.include? :warning
      :warning
    else
      :ok
    end
  end
end
