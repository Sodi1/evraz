class AddRotorNameToAspirator < ActiveRecord::Migration[7.0]
  def change
    add_column :aspirators, :rotor_name, :string
    add_column :device_kinds, :position, :integer, default: 0 
  end
end
