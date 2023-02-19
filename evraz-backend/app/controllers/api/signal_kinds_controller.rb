class Api::SignalKindsController < ApiController
  def index
    q = SignalKind.ransack(params[:q])
    signal_kinds = q.result.includes(:value_kind, :aspirator, :controlled_parameter, :device_kind)

    render json: {
      signal_values: ActiveModelSerializers::SerializableResource.new(signal_kinds,
                                                                      each_serializer: ::SignalKind::ShowSerializer
                                                                     ).as_json
    }
  end
end
