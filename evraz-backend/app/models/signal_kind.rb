class SignalKind < ApplicationRecord
  SETPOINT_CODES = %w[alarm_max alarm_min warning_max warning_min]
  scope :setpoints, -> { where(code: %w[alarm_max alarm_min warning_max warning_min]) }
  belongs_to :device_kind, optional: true
  belongs_to :controlled_parameter, optional: true
  belongs_to :value_kind, optional: true
  belongs_to :aspirator
  # has_many :signal_values
  extend Enumerize
  enumerize :dimension, in: [
      '°С',
      'мм\с',
      '%',
      'А',
      'кВт',
      'Вт',
      'кг\см²',
      'мг/м²',
      'мм.в.ст',
  ]
  def setpoint?
    SETPOINT_CODES.include? code
  end
end