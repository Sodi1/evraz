class SinterMachine::ShowSerializer < BaseSerializer
  attributes :id, :name, :aspirators, :status
  def aspirators
    instance_options[:aspirators]
  end
  def status
    instance_options[:status]
  end
end
