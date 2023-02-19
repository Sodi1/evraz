class Api::AspiratorsController < ApiController
  def index
    q = Aspirator.ransack(params[:q])
    aspirators = q.result

    render json: {
      aspirators: ActiveModelSerializers::SerializableResource.new(aspirators,
                                                                   each_serializer: ::Aspirator::ShortSerializer
                                                                  ).as_json
    }
  end

  def show
    aspirator = Aspirator.find(params[:id])
    serializer_aspirator_service = SerializeAspiratorService.new.call(aspirator, time_machine_offset)
    if serializer_aspirator_service.success?
      render json: {
        aspirator: serializer_aspirator_service.success
      }
    else
      render json: {
        errors: serializer_aspirator_service.failure
      }, status: 500
    end
  end

  def time_machine_offset
    params[:time_machine_offset]
  end
end
