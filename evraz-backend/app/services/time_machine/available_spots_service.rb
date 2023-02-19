require 'dry/monads'

class TimeMachine::AvailableSpotsService
  include Dry::Monads[:result, :do]
  def call
    first_data = EvrazKafkaDatum.order(:offset).first
    last_data = EvrazKafkaDatum.order(:offset).last
    r = {
      minimum_offset: first_data.offset,
      minimum_moment: last_data.payload['moment'],
      maximum_offset: last_data.offset,
      maximum_moment: last_data.payload['moment']

    }
    Success(r)
  end
end
