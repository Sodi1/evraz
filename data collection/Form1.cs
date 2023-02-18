using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAL.Interfaces.Axis;
using EAL.Interfaces;
using EAL.EALConnection;
using EAL.EALConnection.Parameter.ParameterReadWrite;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace newbosch
{
  public partial class Form1 : Form
  {
    private IEALConnection _ealConnBosch = null;
    private double _actTorque = 0.0;
    private double _actVelocity = 0.0;
    private double _actPhaseU = 0.0;
    private double _actPhaseV = 0.0;
    private double _actOutCurrent = 0.0;
    private double _actTemperature = 0.0;
    
    private ushort _msdID = 0;
    private string _actTempMQTT = null;
    private string _actHumpMQTT = null;

    private bool _isMotorAlarm = false;
    private MqttClient _clientMQTT;
    string _clientMQTT_id;

    public Form1()
    {
      InitializeComponent();

    }

    private void ConnectBoschDrive()
    {
      using (PingEALConnection pingBosch = new PingEALConnection())
      {
        EALPingReply replyBosch = pingBosch.Send(txtBox_ip.Text, 4000);
        if (replyBosch.EALStatus == EALIPStatus.Success)
        {
          _ealConnBosch = new EAL.EALConnection.EALConnection(false);
          _ealConnBosch.Connect(txtBox_ip.Text, 5000, 5000, 500, 500);
          btn_ConnectBosch.Enabled = false;
          btn_DisConnBosch.Enabled = true;
          timerUpMotor.Enabled = true;
        }
        else
        {
          MessageBox.Show("Could not connect to the drive in 4 seconds.", "Drive tool");
        }
      }
    }

    private void DisconnectBoschDrive()
    {
      if (_ealConnBosch != null)
      {
        _ealConnBosch.Disconnect();
        _ealConnBosch = null;
        btn_DisConnBosch.Enabled = false;
        btn_ConnectBosch.Enabled = true;
        timerUpMotor.Enabled = false;
        if (chkBox_Server_Conn.Checked)
          chkBox_Server_Conn.Checked = false;
      }
    }

    private void btn_ConnectBosch_Click(object sender, EventArgs e)
    {
      try
      {
        ConnectBoschDrive();
      }
      catch (Exception ex)
      {
        try
        {
          DisconnectBoschDrive();
        }
        catch
        {
          MessageBox.Show("Error Connect/Disconnect");
        }
        MessageBox.Show(ex.ToString());
      }
    }

    private void ClearMotorErrors()
    {
      int motorAddres = (int)nud_AdrMotor.Value;
      if (_ealConnBosch != null)
      {
        if (_ealConnBosch.IsConnected)
        {
          _ealConnBosch.System.Axes[motorAddres].ClearError();
        }
      }
    }

    class MotorData
    {
      public short iot_device;
      public double actTorque;
      public double actVelocity;
      public double actPhaseU;
      public double actPhaseV;
      public double actTemperature;
      public double actOutCurrent;
      public string moment;
    }

    private void timerUpMotor_Tick(object sender, EventArgs e)
    {
      int motorAddres = (int)nud_AdrMotor.Value;
      if (_ealConnBosch != null)
      {
        if (_ealConnBosch.IsConnected)
        {
          double torq = 0;
          torq = _ealConnBosch.Motion.Axes[motorAddres].GetActualTorque();
          _actTorque = torq;
          lblTor.Text = _actTorque.ToString();
          _actVelocity = (_ealConnBosch.Motion.Axes[motorAddres].GetActualVelocity());
          lblSpeed.Text = _actVelocity.ToString();
          _actPhaseU = ((double)_ealConnBosch.Parameter.ReadData("P-0-0067"));
          lbl_Phase_U.Text = _actPhaseU.ToString();
          _actPhaseV = ((double)_ealConnBosch.Parameter.ReadData("P-0-0068"));
          lbl_Phase_V.Text = _actPhaseV.ToString();
          _actOutCurrent = ((double)_ealConnBosch.Parameter.ReadData("P-0-0440"));
          lbl_actOutCur.Text = _actOutCurrent.ToString();
          
          //_actTemperature = ((double)_ealConnBosch.Parameter.ReadData("P-0-0512"));
          
          var tempTest1 = (_ealConnBosch.Parameter.ReadData("P-0-0512"));
          var tempTest2 = (_ealConnBosch.Parameter.ReadData("P-0-4034"));
          var tempTest3 = (_ealConnBosch.Parameter.ReadData("P-0-4037"));
          lbl_Temperature.Text = tempTest1.ToString() + " " + tempTest2.ToString() + " " + tempTest2.ToString();
        }
      }
    }

    private void btnClearError_Click(object sender, EventArgs e)
    {
      ClearMotorErrors();
    }

    private void btn_DisConnBosch_Click(object sender, EventArgs e)
    {
      DisconnectBoschDrive();
    }

    private void chkBox_Server_Conn_CheckedChanged(object sender, EventArgs e)
    {
      if (chkBox_Server_Conn.Checked)
      {
        timerServer.Interval = (int)numUp_upd_serv.Value;
        timerServer.Enabled = true;
      }
      else
      {
        timerServer.Enabled = false;
      }
    }

    private void timerServer_Tick(object sender, EventArgs e)
    {
      SendJSONToKafka();
    }
        
    private void SendJSONToKafka()
    {
      string curtime = DateTime.Now.ToLocalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");

      string motorjson = null;
      motorjson = CollectMotorJson(curtime);
      if (motorjson != null)
      {
        HelperSendJSONToKafka(motorjson);
      }
    }

    private void HelperSendJSONToServer(string data, string url)
    {
      System.Net.HttpWebRequest request = null;
      System.Net.HttpWebResponse response = null;
      System.Net.ServicePointManager.Expect100Continue = true;
      System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072; // for Framework < 4.5

      request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

      request.ContentType = "application/json";
      request.Method = "POST";
      try
      {
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
          streamWriter.Write(data);
          //Console.WriteLine(data);
        }

        using (response = (System.Net.HttpWebResponse)request.GetResponse())
        {
          response.Close();
        }
      }
      catch (Exception ex)
      {
        Thread.Sleep(2000);
      }
    }

    private void HelperSendJSONToKafka(string datafrommotor)
    {
      var conf = new ProducerConfig { BootstrapServers = "82.179.84.219:9001" };

      Action<DeliveryReport<Null, string>> handler = r =>
          Console.WriteLine(!r.Error.IsError
              ? $"Delivered message to {r.TopicPartitionOffset}"
              : $"Delivery Error: {r.Error.Reason}");

      using (var p = new ProducerBuilder<Null, string>(conf).Build())
      {

        p.Produce("bosh-play-machine", new Message<Null, string> { Value = datafrommotor }, handler);
         
        // wait for up to 2 seconds for any inflight messages to be delivered.
        p.Flush(TimeSpan.FromSeconds(2));
      }
    }

    private string CollectMotorJson(string datatime)
    {
      string motorjson = null;
      if (_ealConnBosch == null)
        return motorjson;

      if (!_ealConnBosch.IsConnected)
        return motorjson;

      MotorData motordata = new MotorData();
      motordata.iot_device = 1;
      motordata.actTorque = _actTorque;
      motordata.actVelocity = _actVelocity;
      motordata.actPhaseU = _actPhaseU;
      motordata.actPhaseV = _actPhaseV;
      motordata.actOutCurrent = _actOutCurrent;
      motordata.actTemperature = _actTemperature;
      motordata.moment = datatime;
           
      motorjson = JsonConvert.SerializeObject(motordata);

      return motorjson;
    }

    private string CollectionMQTTJson(string datatime)
    {
      string mqttjson = null;
      if (_clientMQTT == null
        || _actTempMQTT == null
        || _actHumpMQTT == null)
        return mqttjson;

      short idtest = 1;
      mqttjson =
        "{"
        + "\"id\":" + idtest.ToString() + ","
        + "\"deviceId\":" + idtest.ToString() + ","
        + "\"temp\":" + "\"" + _actTempMQTT.ToString() + "\"" + ","
        + "\"hump\":" + "\"" + _actHumpMQTT.ToString() + "\"" + ","
        + "\"date\":" + "\"" + datatime
               + "\"}";

      return mqttjson;
    }


    public void testKafka()
    {
      var conf = new ProducerConfig { BootstrapServers = "82.179.84.219:9001" };
      
      string curtime = DateTime.Now.ToLocalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
      
      Action<DeliveryReport<Null, string>> handler = r =>
          Console.WriteLine(!r.Error.IsError
              ? $"Delivered message to {r.TopicPartitionOffset}"
              : $"Delivery Error: {r.Error.Reason}");

      string motordata = null;
      string motordata1 = null;
      //motordata = CollectMotorJson(curtime);
      short idtest = 1;


      motordata =
        "{"
        + "\"id\":" + idtest + ","
        + "\"servoDriveID\":" + idtest + ","
        + "\"actVelocity\":" + "\"" + _actTorque + "\"" + ","
        + "\"actPhaseU\":" + "\"" + _actPhaseU + "\"" + ","
        + "\"datatime\":" + "\"" + curtime
        + "\"}";

      //Product product = new Product();
      //product.Name = "Apple";
      ////product.Expiry = new DateTime(2008, 12, 28);
      //product.Price = 3.99;
     

      //string json = JsonConvert.SerializeObject(product);

      if (motordata == null)
        return;

      using (var p = new ProducerBuilder<Null, string>(conf).Build())
      {

        p.Produce("hello-world", new Message<Null, string> { Value = "hello" }, handler);

        // wait for up to 10 seconds for any inflight messages to be delivered.
        p.Flush(TimeSpan.FromSeconds(2));
      }

    }

    private void ConnectMQTTBroker()
    {
      _clientMQTT = new MqttClient("dev.rightech.io");

      _clientMQTT_id = Guid.NewGuid().ToString();
      if (_clientMQTT == null)
        return;
      try
      {
        _clientMQTT.Connect(_clientMQTT_id, "pswd", "pswd");
      }
      catch (Exception ex)
      {
      }

      if (_clientMQTT == null)
        return;

      btn_DisConn_MQTT.Enabled = true;
      bnt_Conn_MQTT.Enabled = false;
    }

    private void DisconnectMQTTBroker()
    {
      if (_clientMQTT == null)
        return;
      _clientMQTT.Disconnect();

      _clientMQTT = null;
      _actTempMQTT = null;
      _actHumpMQTT = null;
      btn_DisConn_MQTT.Enabled = false;
      bnt_Conn_MQTT.Enabled = true;
    }

    void client_MqttMsgSubscribed(object sender, MqttMsgPublishEventArgs e)
    {
      //Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
      if (e.Topic == "base/state/temperature")
      {
        _actTempMQTT = Encoding.UTF8.GetString(e.Message);
        this.lbl_MQTT_Temp.BeginInvoke((MethodInvoker)(() => this.lbl_MQTT_Temp.Text = _actTempMQTT.ToString()));
      }
      if (e.Topic == "base/state/acc")
      {
        _actHumpMQTT = Encoding.UTF8.GetString(e.Message);
        this.lbl_MQTT_Hump.BeginInvoke((MethodInvoker)(() => this.lbl_MQTT_Hump.Text = _actHumpMQTT.ToString()));
      }
    }

    private void bnt_Conn_MQTT_Click(object sender, EventArgs e)
    {
      ConnectMQTTBroker();
    }

    private void btn_DisConn_MQTT_Click(object sender, EventArgs e)
    {
      DisconnectMQTTBroker();
    }

    private void btn_Recive_MQTT_Click(object sender, EventArgs e)
    {
      string topic = "base/state/temperature";
      
      if (_clientMQTT == null)
        return;
      _msdID = _clientMQTT.Subscribe(new string[] { topic},
        new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                  MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

      _clientMQTT.MqttMsgPublishReceived += client_MqttMsgSubscribed;
    }

    private void btn_TestJSONSend_Click(object sender, EventArgs e)
    {
      //SendJsonToServer();
      testKafka();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      DisconnectBoschDrive();
      DisconnectMQTTBroker();
    }

    private void bnt_Conn_MQTT_Click_1(object sender, EventArgs e)
    {
      ConnectMQTTBroker();
    }

    private void btn_DisConn_MQTT_Click_1(object sender, EventArgs e)
    {
      DisconnectMQTTBroker();
    }

    private void btn_Recive_MQTT_Click_1(object sender, EventArgs e)
    {
      string topic = "base/state/temperature";
      string topic1 = "base/state/acc";

      if (_clientMQTT == null)
        return;
      _msdID = _clientMQTT.Subscribe(new string[] { topic, topic1 },
        new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                  MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

      _clientMQTT.MqttMsgPublishReceived += client_MqttMsgSubscribed1;
    }

    void client_MqttMsgSubscribed1(object sender, MqttMsgPublishEventArgs e)
    {
      //Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
      if (e.Topic == "base/state/temperature")
      {
        _actTempMQTT = Encoding.UTF8.GetString(e.Message);
        this.lbl_MQTT_Temp.BeginInvoke((MethodInvoker)(() => this.lbl_MQTT_Temp.Text = _actTempMQTT.ToString()));
      }
      if (e.Topic == "base/state/acc")
      {
        _actHumpMQTT = Encoding.UTF8.GetString(e.Message);
        this.lbl_MQTT_Hump.BeginInvoke((MethodInvoker)(() => this.lbl_MQTT_Hump.Text = _actHumpMQTT.ToString()));
      }
    }
  }
}
