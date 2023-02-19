# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema[7.0].define(version: 2023_02_19_012508) do
  # These are extensions that must be enabled in order to support this database
  enable_extension "plpgsql"

  create_table "aspirators", force: :cascade do |t|
    t.bigint "sinter_machine_id"
    t.string "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.string "rotor_name"
    t.datetime "rotor_change_date"
    t.integer "last_offset"
    t.index ["sinter_machine_id"], name: "index_aspirators_on_sinter_machine_id"
  end

  create_table "controlled_parameters", force: :cascade do |t|
    t.string "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  create_table "device_kinds", force: :cascade do |t|
    t.string "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.string "kind"
    t.integer "position", default: 0
  end

  create_table "evraz_kafka_data", force: :cascade do |t|
    t.jsonb "payload"
    t.string "key"
    t.string "md5_payload"
    t.integer "offset"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  create_table "issue_requests", force: :cascade do |t|
    t.bigint "signal_value_id", null: false
    t.string "name"
    t.string "state"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.index ["signal_value_id"], name: "index_issue_requests_on_signal_value_id"
  end

  create_table "play_machine_data", force: :cascade do |t|
    t.jsonb "payload"
    t.string "key"
    t.string "md5_payload"
    t.integer "offset"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  create_table "signal_kinds", force: :cascade do |t|
    t.string "name"
    t.string "code"
    t.string "kafka_code"
    t.string "type_of_signal"
    t.string "active_ibahd"
    t.bigint "device_kind_id"
    t.bigint "controlled_parameter_id"
    t.bigint "value_kind_id"
    t.bigint "aspirator_id"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.string "short_name"
    t.string "dimension"
    t.float "alarm_max"
    t.float "alarm_min"
    t.float "warning_max"
    t.float "warning_min"
    t.boolean "show_notification_on_main_page", default: true
    t.index ["aspirator_id"], name: "index_signal_kinds_on_aspirator_id"
    t.index ["controlled_parameter_id"], name: "index_signal_kinds_on_controlled_parameter_id"
    t.index ["device_kind_id"], name: "index_signal_kinds_on_device_kind_id"
    t.index ["value_kind_id"], name: "index_signal_kinds_on_value_kind_id"
  end

  create_table "signal_values", force: :cascade do |t|
    t.bigint "signal_kind_id", null: false
    t.float "value"
    t.float "alarm_max"
    t.float "warning_max"
    t.float "alarm_min"
    t.float "warning_min"
    t.integer "offset"
    t.datetime "batch_time"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
    t.string "status"
    t.index ["signal_kind_id"], name: "index_signal_values_on_signal_kind_id"
  end

  create_table "sinter_machines", force: :cascade do |t|
    t.string "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  create_table "value_kinds", force: :cascade do |t|
    t.string "name"
    t.datetime "created_at", null: false
    t.datetime "updated_at", null: false
  end

  add_foreign_key "aspirators", "sinter_machines"
  add_foreign_key "issue_requests", "signal_values"
  add_foreign_key "signal_kinds", "aspirators"
  add_foreign_key "signal_kinds", "controlled_parameters"
  add_foreign_key "signal_kinds", "device_kinds"
  add_foreign_key "signal_kinds", "value_kinds"
  add_foreign_key "signal_values", "signal_kinds"
end
