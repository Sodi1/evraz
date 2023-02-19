class UpdateSetpointsJob
  include Sidekiq::Job

  def perform(first_id, last_id)
    
    SignalValue.includes(:signal_kind).where(
        id: first_id..last_id        
    ).each do |sv|
        sv.warning_max ||= sv.signal_kind.warning_max
        sv.warning_min ||= sv.signal_kind.warning_min
        sv.alarm_max ||= sv.signal_kind.alarm_max
        sv.alarm_min ||= sv.signal_kind.alarm_min
        sv.save
        sv.set_status!
    end
  end
end