class UpdateSetpointsService
  def call
    first_id = SignalValue.first.id
    batch_count = SignalValue.count / 150
    150.times.map { |a| (((a - 1) * batch_count) + first_id)..((a * batch_count) + first_id) }.each do |id_range|
        UpdateSetpointsJob.perform_async(id_range.first, id_range.last)
    end
  end
end