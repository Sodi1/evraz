class CreateEvrazKafkaData < ActiveRecord::Migration[7.0]
  def change
    create_table :evraz_kafka_data do |t|
      t.jsonb :payload
      t.string :key
      t.string :md5_payload
      t.integer :offset
      t.timestamps
    end
  end
end
