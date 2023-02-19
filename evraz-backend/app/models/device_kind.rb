class DeviceKind < ApplicationRecord
  extend Enumerize
  enumerize :kind, in: %w[bearings work_aspirator oil_system main_drive valve_position gas_manifold cooler]
  
end
