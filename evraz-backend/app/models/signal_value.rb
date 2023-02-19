class SignalValue < ApplicationRecord
  extend Enumerize
  enumerize :status, in: %w[ok alarm warning]
  belongs_to :signal_kind
  has_one :aspirator, through: :signal_kind
  validates :batch_time, presence: true
  validates :offset, presence: true
  # belongs_to :evraz_kafka_datum, foreign_key: :offset, primary_key: :offset
  def signal_kind_code
    signal_kind&.code
  end
  def signal_kind_short_name
    signal_kind&.short_name
  end
  def signal_kind_dimension
    signal_kind&.dimension
  end
  def set_status!
    return nil if value.nil?

    update_column('status', determine_status)
  end

  def determine_status
    if alarm_max && value > alarm_max
      :alarm
    elsif alarm_min && value < alarm_min
      :alarm
    elsif warning_max && value > warning_max
      :warning
    elsif warning_min && value < warning_min
      :warning
    else
      :ok
    end
  end

  def test_status
    %w[alarm warning ok].sample
  end
end
