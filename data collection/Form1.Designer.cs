namespace newbosch
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.txtBox_ip = new System.Windows.Forms.TextBox();
      this.btn_ConnectBosch = new System.Windows.Forms.Button();
      this.btn_DisConnBosch = new System.Windows.Forms.Button();
      this.nud_AdrMotor = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.lbl_actOutCur = new System.Windows.Forms.Label();
      this.lblTor = new System.Windows.Forms.Label();
      this.lblSpeed = new System.Windows.Forms.Label();
      this.timerUpMotor = new System.Windows.Forms.Timer(this.components);
      this.btnClearError = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.lbl_Temperature = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.lbl_Phase_V = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lbl_Phase_U = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.btn_TestJSONSend = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.numUp_upd_serv = new System.Windows.Forms.NumericUpDown();
      this.chkBox_Server_Conn = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtBox_ip_server = new System.Windows.Forms.TextBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.btn_Unsubscribe = new System.Windows.Forms.Button();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.lbl_MQTT_Hump = new System.Windows.Forms.Label();
      this.lbl_MQTT_Temp = new System.Windows.Forms.Label();
      this.btn_Recive_MQTT = new System.Windows.Forms.Button();
      this.btn_DisConn_MQTT = new System.Windows.Forms.Button();
      this.bnt_Conn_MQTT = new System.Windows.Forms.Button();
      this.timerServer = new System.Windows.Forms.Timer(this.components);
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      ((System.ComponentModel.ISupportInitialize)(this.nud_AdrMotor)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numUp_upd_serv)).BeginInit();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtBox_ip
      // 
      this.txtBox_ip.Location = new System.Drawing.Point(16, 27);
      this.txtBox_ip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.txtBox_ip.Name = "txtBox_ip";
      this.txtBox_ip.Size = new System.Drawing.Size(141, 22);
      this.txtBox_ip.TabIndex = 0;
      this.txtBox_ip.Text = "192.168.129.17";
      // 
      // btn_ConnectBosch
      // 
      this.btn_ConnectBosch.Location = new System.Drawing.Point(44, 78);
      this.btn_ConnectBosch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_ConnectBosch.Name = "btn_ConnectBosch";
      this.btn_ConnectBosch.Size = new System.Drawing.Size(100, 28);
      this.btn_ConnectBosch.TabIndex = 1;
      this.btn_ConnectBosch.Text = "Connect";
      this.btn_ConnectBosch.UseVisualStyleBackColor = true;
      this.btn_ConnectBosch.Click += new System.EventHandler(this.btn_ConnectBosch_Click);
      // 
      // btn_DisConnBosch
      // 
      this.btn_DisConnBosch.Enabled = false;
      this.btn_DisConnBosch.Location = new System.Drawing.Point(44, 113);
      this.btn_DisConnBosch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_DisConnBosch.Name = "btn_DisConnBosch";
      this.btn_DisConnBosch.Size = new System.Drawing.Size(100, 28);
      this.btn_DisConnBosch.TabIndex = 2;
      this.btn_DisConnBosch.Text = "Disonnect";
      this.btn_DisConnBosch.UseVisualStyleBackColor = true;
      this.btn_DisConnBosch.Click += new System.EventHandler(this.btn_DisConnBosch_Click);
      // 
      // nud_AdrMotor
      // 
      this.nud_AdrMotor.Location = new System.Drawing.Point(203, 27);
      this.nud_AdrMotor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.nud_AdrMotor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
      this.nud_AdrMotor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nud_AdrMotor.Name = "nud_AdrMotor";
      this.nud_AdrMotor.Size = new System.Drawing.Size(143, 22);
      this.nud_AdrMotor.TabIndex = 3;
      this.nud_AdrMotor.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(224, 7);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 16);
      this.label1.TabIndex = 4;
      this.label1.Text = "Motor Address";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(40, 7);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 16);
      this.label2.TabIndex = 5;
      this.label2.Text = "Motor Ip";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 166);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(101, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Motor Current, A";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(40, 201);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(115, 16);
      this.label4.TabIndex = 7;
      this.label4.Text = "Motor Torque, Nm";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(41, 239);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(114, 16);
      this.label5.TabIndex = 8;
      this.label5.Text = "Motor Speed, rpm";
      // 
      // lbl_actOutCur
      // 
      this.lbl_actOutCur.AutoSize = true;
      this.lbl_actOutCur.Location = new System.Drawing.Point(208, 166);
      this.lbl_actOutCur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_actOutCur.Name = "lbl_actOutCur";
      this.lbl_actOutCur.Size = new System.Drawing.Size(14, 16);
      this.lbl_actOutCur.TabIndex = 9;
      this.lbl_actOutCur.Text = "0";
      // 
      // lblTor
      // 
      this.lblTor.AutoSize = true;
      this.lblTor.Location = new System.Drawing.Point(208, 201);
      this.lblTor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTor.Name = "lblTor";
      this.lblTor.Size = new System.Drawing.Size(14, 16);
      this.lblTor.TabIndex = 10;
      this.lblTor.Text = "0";
      // 
      // lblSpeed
      // 
      this.lblSpeed.AutoSize = true;
      this.lblSpeed.Location = new System.Drawing.Point(208, 239);
      this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSpeed.Name = "lblSpeed";
      this.lblSpeed.Size = new System.Drawing.Size(14, 16);
      this.lblSpeed.TabIndex = 11;
      this.lblSpeed.Text = "0";
      // 
      // timerUpMotor
      // 
      this.timerUpMotor.Interval = 500;
      this.timerUpMotor.Tick += new System.EventHandler(this.timerUpMotor_Tick);
      // 
      // btnClearError
      // 
      this.btnClearError.Location = new System.Drawing.Point(203, 78);
      this.btnClearError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnClearError.Name = "btnClearError";
      this.btnClearError.Size = new System.Drawing.Size(100, 28);
      this.btnClearError.TabIndex = 12;
      this.btnClearError.Text = "ClearError";
      this.btnClearError.UseVisualStyleBackColor = true;
      this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(-5, 1);
      this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(384, 399);
      this.tabControl1.TabIndex = 13;
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.Color.Ivory;
      this.tabPage1.Controls.Add(this.lbl_Temperature);
      this.tabPage1.Controls.Add(this.label15);
      this.tabPage1.Controls.Add(this.lbl_Phase_V);
      this.tabPage1.Controls.Add(this.label9);
      this.tabPage1.Controls.Add(this.label8);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.lbl_Phase_U);
      this.tabPage1.Controls.Add(this.lblSpeed);
      this.tabPage1.Controls.Add(this.btnClearError);
      this.tabPage1.Controls.Add(this.lblTor);
      this.tabPage1.Controls.Add(this.txtBox_ip);
      this.tabPage1.Controls.Add(this.lbl_actOutCur);
      this.tabPage1.Controls.Add(this.nud_AdrMotor);
      this.tabPage1.Controls.Add(this.label5);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.label4);
      this.tabPage1.Controls.Add(this.btn_ConnectBosch);
      this.tabPage1.Controls.Add(this.label3);
      this.tabPage1.Controls.Add(this.btn_DisConnBosch);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabPage1.Size = new System.Drawing.Size(376, 370);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Motor";
      // 
      // lbl_Temperature
      // 
      this.lbl_Temperature.AutoSize = true;
      this.lbl_Temperature.Location = new System.Drawing.Point(208, 332);
      this.lbl_Temperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_Temperature.Name = "lbl_Temperature";
      this.lbl_Temperature.Size = new System.Drawing.Size(14, 16);
      this.lbl_Temperature.TabIndex = 17;
      this.lbl_Temperature.Text = "0";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(41, 332);
      this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(53, 16);
      this.label15.TabIndex = 16;
      this.label15.Text = "Motor T";
      // 
      // lbl_Phase_V
      // 
      this.lbl_Phase_V.AutoSize = true;
      this.lbl_Phase_V.Location = new System.Drawing.Point(208, 299);
      this.lbl_Phase_V.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_Phase_V.Name = "lbl_Phase_V";
      this.lbl_Phase_V.Size = new System.Drawing.Size(14, 16);
      this.lbl_Phase_V.TabIndex = 15;
      this.lbl_Phase_V.Text = "0";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(41, 300);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(94, 16);
      this.label9.TabIndex = 14;
      this.label9.Text = "Motor phase V";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(41, 271);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(95, 16);
      this.label8.TabIndex = 13;
      this.label8.Text = "Motor phase U";
      // 
      // lbl_Phase_U
      // 
      this.lbl_Phase_U.AutoSize = true;
      this.lbl_Phase_U.Location = new System.Drawing.Point(208, 271);
      this.lbl_Phase_U.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_Phase_U.Name = "lbl_Phase_U";
      this.lbl_Phase_U.Size = new System.Drawing.Size(14, 16);
      this.lbl_Phase_U.TabIndex = 11;
      this.lbl_Phase_U.Text = "0";
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.Color.LightGray;
      this.tabPage2.Controls.Add(this.btn_TestJSONSend);
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.numUp_upd_serv);
      this.tabPage2.Controls.Add(this.chkBox_Server_Conn);
      this.tabPage2.Controls.Add(this.label6);
      this.tabPage2.Controls.Add(this.txtBox_ip_server);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabPage2.Size = new System.Drawing.Size(376, 370);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Server";
      // 
      // btn_TestJSONSend
      // 
      this.btn_TestJSONSend.Location = new System.Drawing.Point(119, 199);
      this.btn_TestJSONSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_TestJSONSend.Name = "btn_TestJSONSend";
      this.btn_TestJSONSend.Size = new System.Drawing.Size(100, 28);
      this.btn_TestJSONSend.TabIndex = 5;
      this.btn_TestJSONSend.Text = "TestSend";
      this.btn_TestJSONSend.UseVisualStyleBackColor = true;
      this.btn_TestJSONSend.Click += new System.EventHandler(this.btn_TestJSONSend_Click);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(131, 84);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(86, 16);
      this.label7.TabIndex = 4;
      this.label7.Text = "Time Update";
      // 
      // numUp_upd_serv
      // 
      this.numUp_upd_serv.Location = new System.Drawing.Point(95, 103);
      this.numUp_upd_serv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.numUp_upd_serv.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
      this.numUp_upd_serv.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.numUp_upd_serv.Name = "numUp_upd_serv";
      this.numUp_upd_serv.Size = new System.Drawing.Size(153, 22);
      this.numUp_upd_serv.TabIndex = 3;
      this.numUp_upd_serv.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // chkBox_Server_Conn
      // 
      this.chkBox_Server_Conn.AutoSize = true;
      this.chkBox_Server_Conn.Location = new System.Drawing.Point(119, 171);
      this.chkBox_Server_Conn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.chkBox_Server_Conn.Name = "chkBox_Server_Conn";
      this.chkBox_Server_Conn.Size = new System.Drawing.Size(93, 20);
      this.chkBox_Server_Conn.TabIndex = 2;
      this.chkBox_Server_Conn.Text = "Send Data";
      this.chkBox_Server_Conn.UseVisualStyleBackColor = true;
      this.chkBox_Server_Conn.CheckedChanged += new System.EventHandler(this.chkBox_Server_Conn_CheckedChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(143, 26);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(62, 16);
      this.label6.TabIndex = 1;
      this.label6.Text = "Server IP";
      // 
      // txtBox_ip_server
      // 
      this.txtBox_ip_server.Location = new System.Drawing.Point(95, 46);
      this.txtBox_ip_server.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.txtBox_ip_server.Name = "txtBox_ip_server";
      this.txtBox_ip_server.Size = new System.Drawing.Size(152, 22);
      this.txtBox_ip_server.TabIndex = 0;
      this.txtBox_ip_server.Text = "https://kovalev.team";
      // 
      // tabPage3
      // 
      this.tabPage3.BackColor = System.Drawing.Color.LightSteelBlue;
      this.tabPage3.Controls.Add(this.btn_Unsubscribe);
      this.tabPage3.Controls.Add(this.label11);
      this.tabPage3.Controls.Add(this.label10);
      this.tabPage3.Controls.Add(this.lbl_MQTT_Hump);
      this.tabPage3.Controls.Add(this.lbl_MQTT_Temp);
      this.tabPage3.Controls.Add(this.btn_Recive_MQTT);
      this.tabPage3.Controls.Add(this.btn_DisConn_MQTT);
      this.tabPage3.Controls.Add(this.bnt_Conn_MQTT);
      this.tabPage3.Location = new System.Drawing.Point(4, 25);
      this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(376, 370);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "MQTT";
      // 
      // btn_Unsubscribe
      // 
      this.btn_Unsubscribe.Location = new System.Drawing.Point(187, 132);
      this.btn_Unsubscribe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_Unsubscribe.Name = "btn_Unsubscribe";
      this.btn_Unsubscribe.Size = new System.Drawing.Size(100, 28);
      this.btn_Unsubscribe.TabIndex = 9;
      this.btn_Unsubscribe.Text = "Unsubscribe";
      this.btn_Unsubscribe.UseVisualStyleBackColor = true;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(49, 286);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(43, 16);
      this.label11.TabIndex = 8;
      this.label11.Text = "Hump";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(49, 252);
      this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(43, 16);
      this.label10.TabIndex = 7;
      this.label10.Text = "Temp";
      // 
      // lbl_MQTT_Hump
      // 
      this.lbl_MQTT_Hump.AutoSize = true;
      this.lbl_MQTT_Hump.Location = new System.Drawing.Point(211, 286);
      this.lbl_MQTT_Hump.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_MQTT_Hump.Name = "lbl_MQTT_Hump";
      this.lbl_MQTT_Hump.Size = new System.Drawing.Size(14, 16);
      this.lbl_MQTT_Hump.TabIndex = 6;
      this.lbl_MQTT_Hump.Text = "0";
      // 
      // lbl_MQTT_Temp
      // 
      this.lbl_MQTT_Temp.AutoSize = true;
      this.lbl_MQTT_Temp.Location = new System.Drawing.Point(211, 252);
      this.lbl_MQTT_Temp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_MQTT_Temp.Name = "lbl_MQTT_Temp";
      this.lbl_MQTT_Temp.Size = new System.Drawing.Size(14, 16);
      this.lbl_MQTT_Temp.TabIndex = 5;
      this.lbl_MQTT_Temp.Text = "0";
      // 
      // btn_Recive_MQTT
      // 
      this.btn_Recive_MQTT.Location = new System.Drawing.Point(53, 132);
      this.btn_Recive_MQTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_Recive_MQTT.Name = "btn_Recive_MQTT";
      this.btn_Recive_MQTT.Size = new System.Drawing.Size(100, 28);
      this.btn_Recive_MQTT.TabIndex = 4;
      this.btn_Recive_MQTT.Text = "Subscribe";
      this.btn_Recive_MQTT.UseVisualStyleBackColor = true;
      this.btn_Recive_MQTT.Click += new System.EventHandler(this.btn_Recive_MQTT_Click_1);
      // 
      // btn_DisConn_MQTT
      // 
      this.btn_DisConn_MQTT.Enabled = false;
      this.btn_DisConn_MQTT.Location = new System.Drawing.Point(187, 68);
      this.btn_DisConn_MQTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btn_DisConn_MQTT.Name = "btn_DisConn_MQTT";
      this.btn_DisConn_MQTT.Size = new System.Drawing.Size(100, 28);
      this.btn_DisConn_MQTT.TabIndex = 3;
      this.btn_DisConn_MQTT.Text = "Disonnect";
      this.btn_DisConn_MQTT.UseVisualStyleBackColor = true;
      this.btn_DisConn_MQTT.Click += new System.EventHandler(this.btn_DisConn_MQTT_Click_1);
      // 
      // bnt_Conn_MQTT
      // 
      this.bnt_Conn_MQTT.Location = new System.Drawing.Point(53, 68);
      this.bnt_Conn_MQTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.bnt_Conn_MQTT.Name = "bnt_Conn_MQTT";
      this.bnt_Conn_MQTT.Size = new System.Drawing.Size(100, 28);
      this.bnt_Conn_MQTT.TabIndex = 2;
      this.bnt_Conn_MQTT.Text = "Connect";
      this.bnt_Conn_MQTT.UseVisualStyleBackColor = true;
      this.bnt_Conn_MQTT.Click += new System.EventHandler(this.bnt_Conn_MQTT_Click_1);
      // 
      // timerServer
      // 
      this.timerServer.Interval = 1000;
      this.timerServer.Tick += new System.EventHandler(this.timerServer_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(379, 393);
      this.Controls.Add(this.tabControl1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Form1";
      this.Text = "EVRAZ";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.nud_AdrMotor)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numUp_upd_serv)).EndInit();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtBox_ip;
    private System.Windows.Forms.Button btn_ConnectBosch;
    private System.Windows.Forms.Button btn_DisConnBosch;
    private System.Windows.Forms.NumericUpDown nud_AdrMotor;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lbl_actOutCur;
    private System.Windows.Forms.Label lblTor;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.Timer timerUpMotor;
    private System.Windows.Forms.Button btnClearError;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.CheckBox chkBox_Server_Conn;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtBox_ip_server;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown numUp_upd_serv;
    private System.Windows.Forms.Timer timerServer;
    private System.Windows.Forms.Label lbl_Phase_V;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label lbl_Phase_U;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button bnt_Conn_MQTT;
    private System.Windows.Forms.Button btn_DisConn_MQTT;
    private System.Windows.Forms.Label lbl_MQTT_Temp;
    private System.Windows.Forms.Button btn_Recive_MQTT;
    private System.Windows.Forms.Button btn_TestJSONSend;
    private System.Windows.Forms.Button btn_Unsubscribe;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label lbl_MQTT_Hump;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.Label lbl_Temperature;
    private System.Windows.Forms.Label label15;
  }
}

