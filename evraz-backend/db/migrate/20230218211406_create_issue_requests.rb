class CreateIssueRequests < ActiveRecord::Migration[7.0]
  def change
    create_table :issue_requests do |t|
      t.references :signal_value, null: false, foreign_key: true
      t.string :name
      t.string :state

      t.timestamps
    end
  end
end
