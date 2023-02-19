class AddSetpointsToSignalKind < ActiveRecord::Migration[7.0]
  def change
    add_column :signal_kinds, :alarm_max, :float
    add_column :signal_kinds, :alarm_min, :float
    add_column :signal_kinds, :warning_max, :float
    add_column :signal_kinds, :warning_min, :float
  end
end
