class AddLastOffsetToaspirator < ActiveRecord::Migration[7.0]
  def change
    add_column :aspirators, :last_offset, :integer
  end
end
