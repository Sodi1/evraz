require 'dry/monads'
require 'csv'

class ImportSignalKindService
  include Dry::Monads[:result, :do]
  attr_reader :rows

  def call(path = 'data/Маппинг сигналов (4).csv')
    SignalKind.destroy_all
    DeviceKind.destroy_all
    ControlledParameter.destroy_all
    ValueKind.destroy_all
    @rows = handle_csv_file(path)
    Success('ok')
  end

  def handle_csv_file(path)
    rows = CSV.read(path)

    # ["DeviceKind", "ControlledParameter", "ValueKind", "code", "kafka_code", "name", "type_of_signal", "active_ibahd", "aspirator"]

    headers = rows.shift
    rows.map do |row|
      device_kind = DeviceKind.find_or_create_by(name: row[headers.index('DeviceKind')])
      controlled_parameter = ControlledParameter.find_or_create_by(name: row[headers.index('ControlledParameter')])
      value_kind = ValueKind.find_or_create_by(name: row[headers.index('ValueKind')])
      aspirator = Aspirator.find_or_create_by(name: row[headers.index('aspirator')])
      
      s = SignalKind.create(
        name: row[headers.index('name')],
        code: row[headers.index('code')],
        kafka_code: row[headers.index('kafka_code')],
        type_of_signal: row[headers.index('type_of_signal')],
        value_kind: value_kind,
        controlled_parameter: controlled_parameter,
        device_kind: device_kind,
        active_ibahd: row[headers.index('active_ibahd')],
        aspirator: aspirator
      )
    end
  end
end
