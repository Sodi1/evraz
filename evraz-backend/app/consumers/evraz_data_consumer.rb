
class EvrazDataConsumer < Racecar::Consumer
  subscribes_to "zsmk-9433-dev-01", start_from_beginning: false
  self.parallel_workers = 5
  def process(message)
    JSON.parse(message.value)
    payload = JSON.parse(message.value)
    md5_payload = Digest::MD5.hexdigest message.value
    kafka_data = ::EvrazKafkaDatum.create(
        payload: payload,
        key: message.key,
        offset: message.offset,
        md5_payload: md5_payload
    ) if ::EvrazKafkaDatum.find_by_md5_payload(md5_payload).nil?
    if kafka_data.present?
      CreateSignalValuesJob.perform_async(kafka_data.id)
    end
  end
end