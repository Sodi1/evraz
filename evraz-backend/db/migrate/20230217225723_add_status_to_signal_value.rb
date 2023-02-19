class AddStatusToSignalValue < ActiveRecord::Migration[7.0]
  def change
    add_column :signal_values, :status, :string
  end
end
