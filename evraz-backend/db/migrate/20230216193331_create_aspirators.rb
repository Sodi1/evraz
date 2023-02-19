class CreateAspirators < ActiveRecord::Migration[7.0]
  def change
    create_table :aspirators do |t|
      t.references :sinter_machine, null: false, foreign_key: true
      t.string :name

      t.timestamps
    end
  end
end
