class IssueRequest::ShowSerializer < BaseSerializer
  attributes :id, :description, :state, :aspirator, :signal_value, :created_at

  def description
    object.signal_value.signal_kind.name
  end

  def signal_value
    SignalValue::ShowSerializer.new(object.signal_value)
  end

  def aspirator
    Aspirator::ShortSerializer.new(object.signal_value.signal_kind.aspirator)
  end
end
