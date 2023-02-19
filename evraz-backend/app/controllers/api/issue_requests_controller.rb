class Api::IssueRequestsController < ApplicationController
  def index
    issue_requests = IssueRequest.where(state: state).includes(:signal_value,
                                                               signal_value: [
                                                                 signal_kind: [
                                                                   :device_kind, :controlled_parameter, :value_kind,
                                                                   { aspirator: [:sinter_machine] }
                                                                 ]
                                                               ]
                                                              ).order(created_at: :desc)

    render json:
    {
      issue_requests: ActiveModelSerializers::SerializableResource.new(issue_requests,
                                                                       each_serializer: ::IssueRequest::ShowSerializer
                                                                      ).as_json
    }
  end

  def state
    params[:state] || :open
  end
end
