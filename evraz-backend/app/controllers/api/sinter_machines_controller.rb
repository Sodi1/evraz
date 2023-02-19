class Api::SinterMachinesController < ApiController
  def index
    render json: {
      sinter_machines: SinterMachine.includes(aspirators: [signal_kinds: [:device_kind]]).all.map do |sinter_machine|
                         SerializeSinterMachineService.new.call(sinter_machine, time_machine_offset).success
                       end.compact
    }
  end

  def show
    sinter_machine = SinterMachine.find(params[:id])
    serialized_sinter_machine_service = SerializeSinterMachineService.new.call(sinter_machine, time_machine_offset)
    if serialized_sinter_machine_service.success?
      render json: {
        sinter_machine: serialized_sinter_machine_service.success
      }
    else
      render json: {
        errrors: serialized_sinter_machine_service.failure
      }, status: 500
    end
  end

  def time_machine_offset
    params[:time_machine_offset]
  end
end
