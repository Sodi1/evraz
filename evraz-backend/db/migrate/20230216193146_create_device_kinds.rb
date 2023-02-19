class CreateDeviceKinds < ActiveRecord::Migration[7.0]
  def change
    create_table :device_kinds do |t|
      t.string :name

      t.timestamps
    end
  end
end
