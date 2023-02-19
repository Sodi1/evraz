require 'dry/monads'

class SerializeAspiratorService
  include Dry::Monads[:result, :do]
  def call(aspirator, time_machine_offset = nil)
    current_data = EvrazKafkaDatum.find_by_offset(time_machine_offset) || EvrazKafkaDatum.order(:offset).last
    batch_time = begin
      current_data.payload['moment'].in_time_zone('UTC')
    rescue StandardError
      nil
    end
    
    aspirator_current_status = aspirator.status(current_data.offset)
    sensor_payload = yield SerializeSensorsPayloadService.new.call(aspirator, time_machine_offset)
    serialized_aspirator = Aspirator::ShowSerializer.new(aspirator, sensor_payload: sensor_payload, batch_time: batch_time, status: aspirator_current_status).as_json
    Success(serialized_aspirator)
  end
end
