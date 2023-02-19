class RemoveAspiratorConstraints < ActiveRecord::Migration[7.0]
  def change
    change_column :aspirators, :sinter_machine_id, :bigint, :null => true
  end
end
