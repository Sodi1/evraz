class AddKindToDeviceKind < ActiveRecord::Migration[7.0]
  def change
    add_column :device_kinds, :kind, :string
  end
end
