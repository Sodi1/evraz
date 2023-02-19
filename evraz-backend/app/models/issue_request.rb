class IssueRequest < ApplicationRecord
  extend Enumerize
  enumerize :state, in: %w[open closed]
  belongs_to :signal_value
end
