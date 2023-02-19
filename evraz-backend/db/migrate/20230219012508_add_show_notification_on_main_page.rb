class AddShowNotificationOnMainPage < ActiveRecord::Migration[7.0]
  def change
    add_column :signal_kinds, :show_notification_on_main_page, :boolean, default: true
  end
end
