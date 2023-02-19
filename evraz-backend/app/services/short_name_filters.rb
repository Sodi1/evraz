
class ShortNameFilters
  def call
    SignalKind.includes(:device_kind).where(device_kind: { kind: :bearings }).map do |signal_kind|
      if signal_kind.code == 'temperature'
        signal_kind.short_name = 'Т'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
      if signal_kind.code == 'vibration_horizontal'
        signal_kind.short_name = 'Гориз'
        signal_kind.dimension = 'мм\с'
        signal_kind.save
      end
      if signal_kind.code == 'vibration_vertical'
        signal_kind.short_name = 'Верт'
        signal_kind.dimension = 'мм\с'
        signal_kind.save
      end
      if signal_kind.code == 'vibration_axial'
        signal_kind.short_name = 'Ось'
        signal_kind.dimension = 'мм\с'
        signal_kind.save
      end
    end
    SignalKind.includes(:device_kind).where(device_kind: { kind: :oil_system }).map do |signal_kind|
      if signal_kind.code == 'oil_level'
        signal_kind.short_name = 'Уровень масла'
        signal_kind.dimension = '%'
        signal_kind.save
      end
      if signal_kind.code == 'oil_pressure'
        signal_kind.short_name = 'Давление масла'
        signal_kind.dimension = 'кг\см²'
        signal_kind.save
      end
    end
    SignalKind.includes(:device_kind).where(device_kind: { kind: :main_drive }).map do |signal_kind|
      if signal_kind.code == 'rotor_current'
        signal_kind.short_name = 'Ток'
        signal_kind.dimension = 'А'
        signal_kind.save
      end
      if signal_kind.code == 'stator_current'
        signal_kind.short_name = 'Ток'
        signal_kind.dimension = 'А'
        signal_kind.save
      end
      if signal_kind.code == 'rotor_voltage'
        signal_kind.short_name = 'Напряжение ротера'
        signal_kind.dimension = 'кВт'
        signal_kind.save
      end
      if signal_kind.code == 'stator_voltage'
        signal_kind.short_name = 'Напряжение статера'
        signal_kind.dimension = 'кВт'
        signal_kind.save
      end
    end
    SignalKind.includes(:device_kind).where(device_kind: { kind: :gas_manifold }).map do |signal_kind|
      if signal_kind.code == 'temperature_before'
        signal_kind.short_name = 'Температура газа'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
      if signal_kind.code == 'underpressure_before'
        signal_kind.short_name = 'Разряжение'
        signal_kind.dimension = 'мм.в.ст'
        signal_kind.save
      end
    end
    SignalKind.includes(:device_kind).where(device_kind: { kind: :cooler }).map do |signal_kind|
      if signal_kind.code == 'temperature_before' && signal_kind.controlled_parameter.name = 'Вода'
        signal_kind.short_name = 'Т воды до'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
      if signal_kind.code == 'temperature_after' && signal_kind.controlled_parameter.name = 'Вода'
        signal_kind.short_name = 'Т воды после'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
      if signal_kind.code == 'temperature_before' && signal_kind.controlled_parameter.name = 'Масло'
        signal_kind.short_name = 'Т масла до'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
      if signal_kind.code == 'temperature_after' && signal_kind.controlled_parameter.name = 'Масло'
        signal_kind.short_name = 'Т масла после'
        signal_kind.dimension = '°С'
        signal_kind.save
      end
    end

    SignalKind.includes(:device_kind).where(device_kind: { kind: :valve_position }).map do |signal_kind|
      if signal_kind.code == 'gas_valve_closed' && signal_kind.controlled_parameter.name = 'Вода'
        signal_kind.short_name = 'Газовая задвижка закрыта'
        signal_kind.dimension = ''
        signal_kind.save
      end
      if signal_kind.code == 'gas_valve_open' && signal_kind.controlled_parameter.name = 'Вода'
        signal_kind.short_name = 'Газовая задвижка открыта'
        signal_kind.dimension = ''
        signal_kind.save
      end
      if signal_kind.code == 'gas_valve_position' && signal_kind.controlled_parameter.name = 'Масло'
        signal_kind.short_name = 'Позиция'
        signal_kind.dimension = '%'
        signal_kind.save
      end
      if signal_kind.code == 'work'
        signal_kind.short_name = 'Работа'
      end
    end


  end
end
