class CreateSignalValues < ActiveRecord::Migration[7.0]
  def change
    create_table :signal_values do |t|
      t.references :signal_kind, null: false, foreign_key: true
      t.float :value
      t.float :alarm_max
      t.float :warning_max
      t.float :alarm_min
      t.float :warning_min
      t.integer :offset
      t.datetime :batch_time
      t.timestamps
    end
  end
end
