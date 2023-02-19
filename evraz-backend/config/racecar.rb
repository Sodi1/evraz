Racecar.configure do |config|
  # Each config variable can be set using a writer attribute.
  # config.brokers = ServiceDiscovery.find("kafka-brokers")
  config.group_id = '16К20'
  config.client_id = '16К20'
  config.ssl_ca_location = 'config/credentials/kafka.pem'
  config.security_protocol = 'sasl_ssl'
  config.sasl_mechanism = 'SCRAM-SHA-512'
  config.sasl_username = '9433_reader'
  config.sasl_password = 'eUIpgWu0PWTJaTrjhjQD3.hoyhntiK'
end
