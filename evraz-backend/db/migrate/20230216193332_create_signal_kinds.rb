class CreateSignalKinds < ActiveRecord::Migration[7.0]
  def change
    create_table :signal_kinds do |t|
      t.string :name
      t.string :code
      t.string :kafka_code
      t.string :type_of_signal
      t.string :active_ibahd
      t.references :device_kind, foreign_key: true
      t.references :controlled_parameter, foreign_key: true
      t.references :value_kind, foreign_key: true
      t.references :aspirator, foreign_key: true

      t.timestamps
    end
  end
end
