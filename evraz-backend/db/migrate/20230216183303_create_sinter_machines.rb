class CreateSinterMachines < ActiveRecord::Migration[7.0]
  def change
    create_table :sinter_machines do |t|
      t.string :name

      t.timestamps
    end
  end
end
