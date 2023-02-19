class SignalKind::ShowSerializer < BaseSerializer
  attributes :id, :name, :code, :kafka_code, :type_of_signal, :active_ibahd, :device_kind, :controlled_parameter, :aspirator, :value_kind

  def value_kind
    ValueKind::ShortSerializer.new(object.value_kind)
  end

  def aspirator
    Aspirator::ShortSerializer.new(object.aspirator)
  end

  def controlled_parameter
    Aspirator::ShortSerializer.new(object.controlled_parameter)
  end

  def device_kind
    Aspirator::ShortSerializer.new(object.device_kind)
  end
end
