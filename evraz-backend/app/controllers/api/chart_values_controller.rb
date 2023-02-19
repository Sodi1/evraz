module Api
  class ChartValuesController < ApiController
    def index
      chart_values_service = ChartValuesService.new.call(signal_kind_ids, start_time, end_time, include_setpoints?)
      if chart_values_service.success?
        render json: { charts: chart_values_service.success }
      else
        render json: { errors: chart_values_service.failure }, status: 500
      end
    end

    def signal_kind_ids
      params.require(:signal_kind_ids)
    end

    def start_time
      params.require(:start_time)
    end

    def end_time
      params.require(:end_time)
    end

    def include_setpoints?
      !!params[:include_setpoints]
    end
  end
end
