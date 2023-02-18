#include <PubSubClient.h>
#include <ESP8266WiFi.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#define ONE_WIRE_BUS 2
#include <Wire.h> 
#include "mydef.h"


WiFiClient espClient;
PubSubClient MqttClient(espClient);

// создаём объект для работы с библиотекой OneWire
OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensor(&oneWire);
 
void setup() { // различные установки
  WiFi.begin(WIFI_SSID, WIFI_PASS);
  MqttClient.setServer(MQTT_S, MQTT_P);
  sensor.begin();
  // устанавливаем разрешение датчика от 9 до 12 бит
  sensor.setResolution(12);  
  
Serial.begin(9600); // инициализация COM
}

void loop() {

// Задержка 1 секунды между измерениями

delay(1000);

float temperature;
// отправляем запрос на измерение температуры
sensor.requestTemperatures();
// считываем данные из регистра датчика
temperature = sensor.getTempCByIndex(0);

if(WiFi.status() == WL_CONNECTED)
  {
  //Serial.print(" ");
  Serial.print(WiFi.localIP());
  //Serial.print(" ");
  MqttClient.connect("test-6hkptp", MQTT_U, MQTT_PASS); 
  char x[4] = {0,0,0,0};
  
  /* перевод значения float в массив символов
  t- что переводим
  4 - длина получаемого символьного значения
  2 - количество символов после запятой
  x - куда записываем преобразованные данные*/
  dtostrf(temperature,4,2,x);  
  MqttClient.publish("base/state/temperature",x); // отправка mqtt qos level 1 
  }
}
