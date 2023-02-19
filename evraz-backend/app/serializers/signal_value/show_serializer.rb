class SignalValue::ShowSerializer < BaseSerializer
  attributes :id, :value, :signal_kind_id, :status, :signal_kind_code, :signal_kind_short_name, :signal_kind_dimension, :batch_time
end
