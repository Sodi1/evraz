class RotorDateToSinterMachine < ActiveRecord::Migration[7.0]
  def change
    add_column :aspirators, :rotor_change_date, :datetime
  end
end
