class Aspirator < ApplicationRecord
  belongs_to :sinter_machine, optional: true
  has_many :signal_kinds
  # has_many :signal_values, through: :signal_kinds

  def status(offset = get_last_offset)
    @status ||= {}
    return @status[offset] if @status[offset].present?

    signal_statuses = SignalValue.where(offset: offset, signal_kind: signal_kinds.where(show_notification_on_main_page: true)).map(&:status).compact
    @status[offset] = if signal_statuses.include? :alarm
                        :alarm
                      elsif signal_statuses.include? :warning
                        :warning
                      else
                        :ok
                      end
  end

  def get_last_offset
    last_offset || SignalValue.where(signal_kind: signal_kinds).order(offset: :desc).limit(1).first.offset
  end
end
