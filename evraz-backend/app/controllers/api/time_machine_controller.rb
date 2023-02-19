class Api::TimeMachineController < ApplicationController
  def available_spots
    available_spots_service = TimeMachine::AvailableSpotsService.new.call
    if available_spots_service.success?
      render json:
      {
        available_spots: available_spots_service.success
      }
    else
      render json: {
        errors: available_spots_service.failure
      }
    end
  end
end
