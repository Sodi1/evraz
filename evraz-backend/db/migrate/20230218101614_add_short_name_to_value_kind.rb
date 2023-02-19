class AddShortNameToValueKind < ActiveRecord::Migration[7.0]
  def change
    add_column :signal_kinds, :short_name, :string
    add_column :signal_kinds, :dimension, :string
  end
end
