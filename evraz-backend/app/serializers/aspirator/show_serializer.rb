class Aspirator::ShowSerializer < BaseSerializer
  attributes :id, :name, :rotor_name, :rotor_change_date, :sensors_payload, :batch_time, :status

  def status
    instance_options[:status]
  end

  def batch_time
    instance_options[:batch_time]
  end

  def sensors_payload
    instance_options[:sensor_payload]
  end
end