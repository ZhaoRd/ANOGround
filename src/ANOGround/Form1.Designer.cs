namespace ANOGround
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flymode = new System.Windows.Forms.Label();
            this.labearmed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stabilizebutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttondisarm = new System.Windows.Forms.Button();
            this.alttextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.autobutton = new System.Windows.Forms.Button();
            this.landbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flybutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonLoadOffMaps = new System.Windows.Forms.Button();
            this.chackbox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_com_open = new System.Windows.Forms.Button();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_comname = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip_secMapCtrl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.写入当前航点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设为家ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timerReplay = new System.Windows.Forms.Timer(this.components);
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.alt_warn = new System.Windows.Forms.TextBox();
            this.Commands = new System.Windows.Forms.DataGridView();
            this.Command = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Param1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Param4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Up = new System.Windows.Forms.DataGridViewImageColumn();
            this.Down = new System.Windows.Forms.DataGridViewImageColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelbRoutePlanStatus = new System.Windows.Forms.Label();
            this.buttonClearWP = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonPlanningwp = new System.Windows.Forms.Button();
            this.label78 = new System.Windows.Forms.Label();
            this.labelDist2Home = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.labelsecLAT = new System.Windows.Forms.Label();
            this.labelsecLOG = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxHomeALT = new System.Windows.Forms.TextBox();
            this.textBoxHomeLOG = new System.Windows.Forms.TextBox();
            this.textBoxHomeLAT = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.buttonwritewp = new System.Windows.Forms.Button();
            this.buttonreadwp = new System.Windows.Forms.Button();
            this.gmap_setairway = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage_set = new System.Windows.Forms.TabPage();
            this.tabPage_rxtx = new System.Windows.Forms.TabPage();
            this.verticalSpeedIndicatorInstrumentControl1 = new AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl();
            this.labelSatelnum = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.labelMapProvider = new System.Windows.Forms.Label();
            this.labelmainLAT = new System.Windows.Forms.Label();
            this.labelmainLOG = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.hx_Control1 = new AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl();
            this.att_Control1 = new AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip_secMapCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage_rxtx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.flymode);
            this.groupBox1.Controls.Add(this.labearmed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.buttonLoadOffMaps);
            this.groupBox1.Controls.Add(this.chackbox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_com_open);
            this.groupBox1.Controls.Add(this.comboBox_baudrate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_comname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1220, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(219, 860);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // flymode
            // 
            this.flymode.AutoSize = true;
            this.flymode.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flymode.ForeColor = System.Drawing.Color.Red;
            this.flymode.Location = new System.Drawing.Point(7, 544);
            this.flymode.Name = "flymode";
            this.flymode.Size = new System.Drawing.Size(108, 19);
            this.flymode.TabIndex = 80;
            this.flymode.Text = "Stabilize";
            // 
            // labearmed
            // 
            this.labearmed.AutoSize = true;
            this.labearmed.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labearmed.ForeColor = System.Drawing.Color.Red;
            this.labearmed.Location = new System.Drawing.Point(-5, 772);
            this.labearmed.Name = "labearmed";
            this.labearmed.Size = new System.Drawing.Size(189, 28);
            this.labearmed.TabIndex = 79;
            this.labearmed.Text = "已锁定(LOCK)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 79;
            this.label5.Text = "飞行模式";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.stabilizebutton);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.buttondisarm);
            this.panel2.Controls.Add(this.alttextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button14);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.autobutton);
            this.panel2.Controls.Add(this.landbutton);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.flybutton);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 305);
            this.panel2.TabIndex = 79;
            // 
            // stabilizebutton
            // 
            this.stabilizebutton.BackColor = System.Drawing.Color.Red;
            this.stabilizebutton.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stabilizebutton.ForeColor = System.Drawing.Color.Black;
            this.stabilizebutton.Location = new System.Drawing.Point(73, 206);
            this.stabilizebutton.Name = "stabilizebutton";
            this.stabilizebutton.Size = new System.Drawing.Size(54, 96);
            this.stabilizebutton.TabIndex = 81;
            this.stabilizebutton.Text = "自稳";
            this.stabilizebutton.UseVisualStyleBackColor = false;
            this.stabilizebutton.Click += new System.EventHandler(this.stabilizebutton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 79;
            this.label6.Text = "M(米)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // buttondisarm
            // 
            this.buttondisarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttondisarm.Location = new System.Drawing.Point(73, 151);
            this.buttondisarm.Name = "buttondisarm";
            this.buttondisarm.Size = new System.Drawing.Size(58, 43);
            this.buttondisarm.TabIndex = 79;
            this.buttondisarm.Text = "解锁";
            this.buttondisarm.UseVisualStyleBackColor = false;
            this.buttondisarm.Click += new System.EventHandler(this.buttondisarm_Click);
            // 
            // alttextBox
            // 
            this.alttextBox.Location = new System.Drawing.Point(0, 175);
            this.alttextBox.Name = "alttextBox";
            this.alttextBox.Size = new System.Drawing.Size(33, 25);
            this.alttextBox.TabIndex = 79;
            this.alttextBox.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "起飞高度";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(138, 59);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(53, 40);
            this.button14.TabIndex = 88;
            this.button14.Text = "右";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(138, 105);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(53, 40);
            this.button13.TabIndex = 87;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(138, 13);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(53, 40);
            this.button12.TabIndex = 86;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(73, 105);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 40);
            this.button11.TabIndex = 85;
            this.button11.Text = "后";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(73, 13);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 40);
            this.button10.TabIndex = 84;
            this.button10.Text = "前";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(7, 105);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(53, 40);
            this.button9.TabIndex = 83;
            this.button9.Text = "下降";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 59);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 40);
            this.button8.TabIndex = 82;
            this.button8.Text = "左";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(7, 13);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 40);
            this.button7.TabIndex = 81;
            this.button7.Text = "上升";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // autobutton
            // 
            this.autobutton.Location = new System.Drawing.Point(138, 151);
            this.autobutton.Name = "autobutton";
            this.autobutton.Size = new System.Drawing.Size(58, 37);
            this.autobutton.TabIndex = 79;
            this.autobutton.Text = "AUTO";
            this.autobutton.UseVisualStyleBackColor = true;
            this.autobutton.Click += new System.EventHandler(this.autobutton_Click);
            // 
            // landbutton
            // 
            this.landbutton.Location = new System.Drawing.Point(0, 260);
            this.landbutton.Name = "landbutton";
            this.landbutton.Size = new System.Drawing.Size(67, 44);
            this.landbutton.TabIndex = 79;
            this.landbutton.Text = "着陆";
            this.landbutton.UseVisualStyleBackColor = true;
            this.landbutton.Click += new System.EventHandler(this.landbutton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 44);
            this.button2.TabIndex = 80;
            this.button2.Text = "返航";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flybutton
            // 
            this.flybutton.Location = new System.Drawing.Point(0, 206);
            this.flybutton.Name = "flybutton";
            this.flybutton.Size = new System.Drawing.Size(67, 48);
            this.flybutton.TabIndex = 13;
            this.flybutton.Text = "起飞";
            this.flybutton.UseVisualStyleBackColor = true;
            this.flybutton.Click += new System.EventHandler(this.flybutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 48);
            this.button1.TabIndex = 79;
            this.button1.Text = "悬停";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonLoadOffMaps
            // 
            this.buttonLoadOffMaps.Location = new System.Drawing.Point(109, 113);
            this.buttonLoadOffMaps.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadOffMaps.Name = "buttonLoadOffMaps";
            this.buttonLoadOffMaps.Size = new System.Drawing.Size(82, 26);
            this.buttonLoadOffMaps.TabIndex = 12;
            this.buttonLoadOffMaps.Text = "加载离线地图";
            this.buttonLoadOffMaps.UseVisualStyleBackColor = true;
            this.buttonLoadOffMaps.Click += new System.EventHandler(this.buttonLoadOffMaps_Click);
            // 
            // chackbox2
            // 
            this.chackbox2.AutoSize = true;
            this.chackbox2.Location = new System.Drawing.Point(12, 140);
            this.chackbox2.Margin = new System.Windows.Forms.Padding(4);
            this.chackbox2.Name = "chackbox2";
            this.chackbox2.Size = new System.Drawing.Size(89, 19);
            this.chackbox2.TabIndex = 9;
            this.chackbox2.Text = "离线地图";
            this.chackbox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(11, 113);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "在线地图";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_com_open
            // 
            this.btn_com_open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_com_open.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_com_open.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_com_open.Location = new System.Drawing.Point(68, 75);
            this.btn_com_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_com_open.Name = "btn_com_open";
            this.btn_com_open.Size = new System.Drawing.Size(101, 32);
            this.btn_com_open.TabIndex = 4;
            this.btn_com_open.Text = "建立通信";
            this.btn_com_open.UseVisualStyleBackColor = true;
            this.btn_com_open.Click += new System.EventHandler(this.btn_com_open_Click);
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.FormattingEnabled = true;
            this.comboBox_baudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox_baudrate.Location = new System.Drawing.Point(69, 46);
            this.comboBox_baudrate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            this.comboBox_baudrate.Size = new System.Drawing.Size(100, 23);
            this.comboBox_baudrate.TabIndex = 3;
            this.comboBox_baudrate.SelectedIndexChanged += new System.EventHandler(this.comboBox_baudrate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // comboBox_comname
            // 
            this.comboBox_comname.FormattingEnabled = true;
            this.comboBox_comname.Location = new System.Drawing.Point(68, 12);
            this.comboBox_comname.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_comname.Name = "comboBox_comname";
            this.comboBox_comname.Size = new System.Drawing.Size(101, 23);
            this.comboBox_comname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // contextMenuStrip_secMapCtrl
            // 
            this.contextMenuStrip_secMapCtrl.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_secMapCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.清除任务ToolStripMenuItem,
            this.写入当前航点ToolStripMenuItem,
            this.设为家ToolStripMenuItem});
            this.contextMenuStrip_secMapCtrl.Name = "contextMenuStrip1";
            this.contextMenuStrip_secMapCtrl.Size = new System.Drawing.Size(169, 124);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 24);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(168, 24);
            this.toolStripMenuItem3.Text = "删除航点";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // 清除任务ToolStripMenuItem
            // 
            this.清除任务ToolStripMenuItem.Name = "清除任务ToolStripMenuItem";
            this.清除任务ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.清除任务ToolStripMenuItem.Text = "清除任务";
            // 
            // 写入当前航点ToolStripMenuItem
            // 
            this.写入当前航点ToolStripMenuItem.Name = "写入当前航点ToolStripMenuItem";
            this.写入当前航点ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.写入当前航点ToolStripMenuItem.Text = "写入当前航点";
            // 
            // 设为家ToolStripMenuItem
            // 
            this.设为家ToolStripMenuItem.Enabled = false;
            this.设为家ToolStripMenuItem.Name = "设为家ToolStripMenuItem";
            this.设为家ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.设为家ToolStripMenuItem.Text = "设为家";
            this.设为家ToolStripMenuItem.Click += new System.EventHandler(this.设为家ToolStripMenuItem_Click);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 28);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage7.Size = new System.Drawing.Size(1200, 828);
            this.tabPage7.TabIndex = 9;
            this.tabPage7.Text = "版本说明";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(1200, 828);
            this.tabPage6.TabIndex = 8;
            this.tabPage6.Text = "数传电台设置";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1200, 828);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Text = "地图校准";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(1200, 828);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Text = "遥控器设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1200, 828);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "高级设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1200, 828);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "传感器校准";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.labelbRoutePlanStatus);
            this.tabPage1.Controls.Add(this.buttonClearWP);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.buttonPlanningwp);
            this.tabPage1.Controls.Add(this.label78);
            this.tabPage1.Controls.Add(this.labelDist2Home);
            this.tabPage1.Controls.Add(this.label76);
            this.tabPage1.Controls.Add(this.labelsecLAT);
            this.tabPage1.Controls.Add(this.labelsecLOG);
            this.tabPage1.Controls.Add(this.label75);
            this.tabPage1.Controls.Add(this.label74);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.buttonwritewp);
            this.tabPage1.Controls.Add(this.buttonreadwp);
            this.tabPage1.Controls.Add(this.gmap_setairway);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1200, 828);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "航线规划";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.alt_warn);
            this.panel1.Controls.Add(this.Commands);
            this.panel1.Location = new System.Drawing.Point(3, 600);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 173);
            this.panel1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "告警高度";
            // 
            // alt_warn
            // 
            this.alt_warn.Location = new System.Drawing.Point(79, 3);
            this.alt_warn.Name = "alt_warn";
            this.alt_warn.Size = new System.Drawing.Size(100, 25);
            this.alt_warn.TabIndex = 7;
            // 
            // Commands
            // 
            this.Commands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Commands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Command,
            this.Param1,
            this.Param2,
            this.Param3,
            this.Param4,
            this.Lat,
            this.Lon,
            this.Alt,
            this.Delete,
            this.Up,
            this.Down,
            this.Grad,
            this.Angle,
            this.Dist,
            this.AZ});
            this.Commands.Location = new System.Drawing.Point(1, 31);
            this.Commands.Name = "Commands";
            this.Commands.RowTemplate.Height = 27;
            this.Commands.Size = new System.Drawing.Size(1200, 139);
            this.Commands.TabIndex = 6;
            // 
            // Command
            // 
            this.Command.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Command.HeaderText = "Command";
            this.Command.MinimumWidth = 100;
            this.Command.Name = "Command";
            this.Command.ToolTipText = "APM Command";
            // 
            // Param1
            // 
            this.Param1.HeaderText = "P1";
            this.Param1.MinimumWidth = 60;
            this.Param1.Name = "Param1";
            this.Param1.Width = 60;
            // 
            // Param2
            // 
            this.Param2.HeaderText = "P2";
            this.Param2.MinimumWidth = 60;
            this.Param2.Name = "Param2";
            this.Param2.Width = 60;
            // 
            // Param3
            // 
            this.Param3.HeaderText = "P3";
            this.Param3.MinimumWidth = 60;
            this.Param3.Name = "Param3";
            this.Param3.Width = 60;
            // 
            // Param4
            // 
            this.Param4.HeaderText = "P4";
            this.Param4.MinimumWidth = 60;
            this.Param4.Name = "Param4";
            this.Param4.Width = 60;
            // 
            // Lat
            // 
            this.Lat.HeaderText = "Lat";
            this.Lat.MinimumWidth = 100;
            this.Lat.Name = "Lat";
            // 
            // Lon
            // 
            this.Lon.HeaderText = "Lon";
            this.Lon.MinimumWidth = 100;
            this.Lon.Name = "Lon";
            // 
            // Alt
            // 
            this.Alt.HeaderText = "Alt";
            this.Alt.MinimumWidth = 100;
            this.Alt.Name = "Alt";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 50;
            this.Delete.Name = "Delete";
            this.Delete.Width = 50;
            // 
            // Up
            // 
            this.Up.HeaderText = "Up";
            this.Up.MinimumWidth = 60;
            this.Up.Name = "Up";
            this.Up.Width = 60;
            // 
            // Down
            // 
            this.Down.HeaderText = "Down";
            this.Down.MinimumWidth = 60;
            this.Down.Name = "Down";
            this.Down.Width = 60;
            // 
            // Grad
            // 
            this.Grad.HeaderText = "Grad";
            this.Grad.MinimumWidth = 50;
            this.Grad.Name = "Grad";
            this.Grad.Width = 50;
            // 
            // Angle
            // 
            this.Angle.HeaderText = "Angle";
            this.Angle.MinimumWidth = 50;
            this.Angle.Name = "Angle";
            this.Angle.Width = 50;
            // 
            // Dist
            // 
            this.Dist.HeaderText = "Dist";
            this.Dist.MinimumWidth = 60;
            this.Dist.Name = "Dist";
            this.Dist.Width = 60;
            // 
            // AZ
            // 
            this.AZ.HeaderText = "AZ";
            this.AZ.MinimumWidth = 60;
            this.AZ.Name = "AZ";
            this.AZ.Width = 60;
            // 
            // labelbRoutePlanStatus
            // 
            this.labelbRoutePlanStatus.AutoSize = true;
            this.labelbRoutePlanStatus.Location = new System.Drawing.Point(900, 6);
            this.labelbRoutePlanStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelbRoutePlanStatus.Name = "labelbRoutePlanStatus";
            this.labelbRoutePlanStatus.Size = new System.Drawing.Size(112, 15);
            this.labelbRoutePlanStatus.TabIndex = 20;
            this.labelbRoutePlanStatus.Text = "已退出航点编辑";
            // 
            // buttonClearWP
            // 
            this.buttonClearWP.Location = new System.Drawing.Point(1100, 110);
            this.buttonClearWP.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearWP.Name = "buttonClearWP";
            this.buttonClearWP.Size = new System.Drawing.Size(100, 29);
            this.buttonClearWP.TabIndex = 19;
            this.buttonClearWP.Text = "清除航点";
            this.buttonClearWP.UseVisualStyleBackColor = true;
            this.buttonClearWP.Click += new System.EventHandler(this.buttonClearWP_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1063, 343);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(131, 29);
            this.button6.TabIndex = 18;
            this.button6.Text = "打开航点文件";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1061, 291);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 29);
            this.button5.TabIndex = 17;
            this.button5.Text = "保存航点文件";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonPlanningwp
            // 
            this.buttonPlanningwp.Location = new System.Drawing.Point(1100, -1);
            this.buttonPlanningwp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlanningwp.Name = "buttonPlanningwp";
            this.buttonPlanningwp.Size = new System.Drawing.Size(100, 29);
            this.buttonPlanningwp.TabIndex = 16;
            this.buttonPlanningwp.Text = "规划航点";
            this.buttonPlanningwp.UseVisualStyleBackColor = true;
            this.buttonPlanningwp.Click += new System.EventHandler(this.buttonPlanningwp_Click);
            this.buttonPlanningwp.MouseHover += new System.EventHandler(this.buttonPlanningwp_MouseHover);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(360, 15);
            this.label78.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(22, 15);
            this.label78.TabIndex = 15;
            this.label78.Text = "米";
            // 
            // labelDist2Home
            // 
            this.labelDist2Home.AutoSize = true;
            this.labelDist2Home.Location = new System.Drawing.Point(188, 15);
            this.labelDist2Home.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDist2Home.Name = "labelDist2Home";
            this.labelDist2Home.Size = new System.Drawing.Size(31, 15);
            this.labelDist2Home.TabIndex = 14;
            this.labelDist2Home.Text = "dis";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(137, 15);
            this.label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(45, 15);
            this.label76.TabIndex = 13;
            this.label76.Text = "距离H";
            // 
            // labelsecLAT
            // 
            this.labelsecLAT.AutoSize = true;
            this.labelsecLAT.Location = new System.Drawing.Point(43, 30);
            this.labelsecLAT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelsecLAT.Name = "labelsecLAT";
            this.labelsecLAT.Size = new System.Drawing.Size(63, 15);
            this.labelsecLAT.TabIndex = 12;
            this.labelsecLAT.Text = "label77";
            // 
            // labelsecLOG
            // 
            this.labelsecLOG.AutoSize = true;
            this.labelsecLOG.Location = new System.Drawing.Point(41, 15);
            this.labelsecLOG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelsecLOG.Name = "labelsecLOG";
            this.labelsecLOG.Size = new System.Drawing.Size(63, 15);
            this.labelsecLOG.TabIndex = 11;
            this.labelsecLOG.Text = "label76";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(9, 30);
            this.label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(37, 15);
            this.label75.TabIndex = 10;
            this.label75.Text = "纬度";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(9, 15);
            this.label74.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(37, 15);
            this.label74.TabIndex = 9;
            this.label74.Text = "经度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxHomeALT);
            this.groupBox2.Controls.Add(this.textBoxHomeLOG);
            this.groupBox2.Controls.Add(this.textBoxHomeLAT);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Location = new System.Drawing.Point(1052, 380);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(140, 235);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "起始位置";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBoxHomeALT
            // 
            this.textBoxHomeALT.Location = new System.Drawing.Point(8, 159);
            this.textBoxHomeALT.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHomeALT.Name = "textBoxHomeALT";
            this.textBoxHomeALT.Size = new System.Drawing.Size(121, 25);
            this.textBoxHomeALT.TabIndex = 11;
            // 
            // textBoxHomeLOG
            // 
            this.textBoxHomeLOG.Location = new System.Drawing.Point(11, 102);
            this.textBoxHomeLOG.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHomeLOG.Name = "textBoxHomeLOG";
            this.textBoxHomeLOG.Size = new System.Drawing.Size(121, 25);
            this.textBoxHomeLOG.TabIndex = 10;
            // 
            // textBoxHomeLAT
            // 
            this.textBoxHomeLAT.Location = new System.Drawing.Point(9, 46);
            this.textBoxHomeLAT.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHomeLAT.Name = "textBoxHomeLAT";
            this.textBoxHomeLAT.Size = new System.Drawing.Size(121, 25);
            this.textBoxHomeLAT.TabIndex = 9;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(8, 139);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(67, 15);
            this.label57.TabIndex = 8;
            this.label57.Text = "绝对高度";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(8, 25);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(37, 15);
            this.label58.TabIndex = 6;
            this.label58.Text = "经度";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(8, 84);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(37, 15);
            this.label59.TabIndex = 7;
            this.label59.Text = "纬度";
            // 
            // buttonwritewp
            // 
            this.buttonwritewp.Location = new System.Drawing.Point(1100, 73);
            this.buttonwritewp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonwritewp.Name = "buttonwritewp";
            this.buttonwritewp.Size = new System.Drawing.Size(100, 29);
            this.buttonwritewp.TabIndex = 4;
            this.buttonwritewp.Text = "写入航点";
            this.buttonwritewp.UseVisualStyleBackColor = true;
            this.buttonwritewp.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonreadwp
            // 
            this.buttonreadwp.Location = new System.Drawing.Point(1100, 36);
            this.buttonreadwp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonreadwp.Name = "buttonreadwp";
            this.buttonreadwp.Size = new System.Drawing.Size(100, 29);
            this.buttonreadwp.TabIndex = 3;
            this.buttonreadwp.Text = "读取航点";
            this.buttonreadwp.UseVisualStyleBackColor = true;
            this.buttonreadwp.Click += new System.EventHandler(this.buttonreadwp_Click);
            // 
            // gmap_setairway
            // 
            this.gmap_setairway.Bearing = 0F;
            this.gmap_setairway.CanDragMap = true;
            this.gmap_setairway.ContextMenuStrip = this.contextMenuStrip_secMapCtrl;
            this.gmap_setairway.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap_setairway.GrayScaleMode = false;
            this.gmap_setairway.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap_setairway.LevelsKeepInMemmory = 5;
            this.gmap_setairway.Location = new System.Drawing.Point(-4, 0);
            this.gmap_setairway.Margin = new System.Windows.Forms.Padding(4);
            this.gmap_setairway.MarkersEnabled = true;
            this.gmap_setairway.MaxZoom = 18;
            this.gmap_setairway.MinZoom = 2;
            this.gmap_setairway.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap_setairway.Name = "gmap_setairway";
            this.gmap_setairway.NegativeMode = false;
            this.gmap_setairway.PolygonsEnabled = true;
            this.gmap_setairway.RetryLoadTile = 0;
            this.gmap_setairway.RoutesEnabled = true;
            this.gmap_setairway.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap_setairway.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap_setairway.ShowTileGridLines = false;
            this.gmap_setairway.Size = new System.Drawing.Size(1208, 782);
            this.gmap_setairway.TabIndex = 0;
            this.gmap_setairway.Zoom = 10D;
            this.gmap_setairway.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gmap_setairway_OnMarkerEnter);
            this.gmap_setairway.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gmap_setairway_OnMarkerLeave);
            this.gmap_setairway.OnMapDrag += new GMap.NET.MapDrag(this.gmap_setairway_OnMapDrag);
            this.gmap_setairway.Load += new System.EventHandler(this.gmap_setairway_Load);
            this.gmap_setairway.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gmap_setairway_MouseDown);
            this.gmap_setairway.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gmap_setairway_MouseMove);
            this.gmap_setairway.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gmap_setairway_MouseUp);
            // 
            // tabPage_set
            // 
            this.tabPage_set.Location = new System.Drawing.Point(4, 28);
            this.tabPage_set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_set.Name = "tabPage_set";
            this.tabPage_set.Size = new System.Drawing.Size(1200, 828);
            this.tabPage_set.TabIndex = 2;
            this.tabPage_set.Text = "飞控设置";
            this.tabPage_set.UseVisualStyleBackColor = true;
            // 
            // tabPage_rxtx
            // 
            this.tabPage_rxtx.BackColor = System.Drawing.Color.Black;
            this.tabPage_rxtx.Controls.Add(this.verticalSpeedIndicatorInstrumentControl1);
            this.tabPage_rxtx.Controls.Add(this.labelSatelnum);
            this.tabPage_rxtx.Controls.Add(this.label80);
            this.tabPage_rxtx.Controls.Add(this.comboBox1);
            this.tabPage_rxtx.Controls.Add(this.label77);
            this.tabPage_rxtx.Controls.Add(this.labelMapProvider);
            this.tabPage_rxtx.Controls.Add(this.labelmainLAT);
            this.tabPage_rxtx.Controls.Add(this.labelmainLOG);
            this.tabPage_rxtx.Controls.Add(this.label73);
            this.tabPage_rxtx.Controls.Add(this.label72);
            this.tabPage_rxtx.Controls.Add(this.trackBar1);
            this.tabPage_rxtx.Controls.Add(this.label21);
            this.tabPage_rxtx.Controls.Add(this.label22);
            this.tabPage_rxtx.Controls.Add(this.label19);
            this.tabPage_rxtx.Controls.Add(this.label20);
            this.tabPage_rxtx.Controls.Add(this.label13);
            this.tabPage_rxtx.Controls.Add(this.label14);
            this.tabPage_rxtx.Controls.Add(this.label15);
            this.tabPage_rxtx.Controls.Add(this.label16);
            this.tabPage_rxtx.Controls.Add(this.label11);
            this.tabPage_rxtx.Controls.Add(this.label12);
            this.tabPage_rxtx.Controls.Add(this.label9);
            this.tabPage_rxtx.Controls.Add(this.label10);
            this.tabPage_rxtx.Controls.Add(this.gmap);
            this.tabPage_rxtx.Controls.Add(this.hx_Control1);
            this.tabPage_rxtx.Controls.Add(this.att_Control1);
            this.tabPage_rxtx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage_rxtx.ForeColor = System.Drawing.Color.Red;
            this.tabPage_rxtx.Location = new System.Drawing.Point(4, 28);
            this.tabPage_rxtx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_rxtx.Name = "tabPage_rxtx";
            this.tabPage_rxtx.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_rxtx.Size = new System.Drawing.Size(1200, 828);
            this.tabPage_rxtx.TabIndex = 1;
            this.tabPage_rxtx.Text = "系统监测";
            // 
            // verticalSpeedIndicatorInstrumentControl1
            // 
            this.verticalSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(136, 264);
            this.verticalSpeedIndicatorInstrumentControl1.Name = "verticalSpeedIndicatorInstrumentControl1";
            this.verticalSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(128, 131);
            this.verticalSpeedIndicatorInstrumentControl1.TabIndex = 78;
            this.verticalSpeedIndicatorInstrumentControl1.Text = "verticalSpeedIndicatorInstrumentControl1";
            // 
            // labelSatelnum
            // 
            this.labelSatelnum.AutoSize = true;
            this.labelSatelnum.Location = new System.Drawing.Point(355, 585);
            this.labelSatelnum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSatelnum.Name = "labelSatelnum";
            this.labelSatelnum.Size = new System.Drawing.Size(25, 15);
            this.labelSatelnum.TabIndex = 77;
            this.labelSatelnum.Text = "##";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(281, 585);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(66, 15);
            this.label80.TabIndex = 76;
            this.label80.Text = "GPS星数";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "高德地图",
            "必应卫星地图"});
            this.comboBox1.Location = new System.Drawing.Point(284, 665);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 75;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(281, 628);
            this.label77.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(87, 15);
            this.label77.TabIndex = 74;
            this.label77.Text = "地图供应商";
            // 
            // labelMapProvider
            // 
            this.labelMapProvider.AutoSize = true;
            this.labelMapProvider.ForeColor = System.Drawing.Color.White;
            this.labelMapProvider.Location = new System.Drawing.Point(376, 628);
            this.labelMapProvider.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMapProvider.Name = "labelMapProvider";
            this.labelMapProvider.Size = new System.Drawing.Size(87, 15);
            this.labelMapProvider.TabIndex = 73;
            this.labelMapProvider.Text = "地图提供商";
            // 
            // labelmainLAT
            // 
            this.labelmainLAT.AutoSize = true;
            this.labelmainLAT.BackColor = System.Drawing.Color.Transparent;
            this.labelmainLAT.ForeColor = System.Drawing.Color.White;
            this.labelmainLAT.Location = new System.Drawing.Point(339, 24);
            this.labelmainLAT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelmainLAT.Name = "labelmainLAT";
            this.labelmainLAT.Size = new System.Drawing.Size(43, 15);
            this.labelmainLAT.TabIndex = 72;
            this.labelmainLAT.Text = "0.00";
            // 
            // labelmainLOG
            // 
            this.labelmainLOG.AutoSize = true;
            this.labelmainLOG.ForeColor = System.Drawing.Color.White;
            this.labelmainLOG.Location = new System.Drawing.Point(339, 2);
            this.labelmainLOG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelmainLOG.Name = "labelmainLOG";
            this.labelmainLOG.Size = new System.Drawing.Size(43, 15);
            this.labelmainLOG.TabIndex = 71;
            this.labelmainLOG.Text = "0.00";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.ForeColor = System.Drawing.Color.White;
            this.label73.Location = new System.Drawing.Point(292, 24);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(39, 15);
            this.label73.TabIndex = 70;
            this.label73.Text = "纬度";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(292, 2);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(39, 15);
            this.label72.TabIndex = 69;
            this.label72.Text = "经度";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(780, 719);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 18;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(416, 56);
            this.trackBar1.TabIndex = 68;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Snow;
            this.label21.Location = new System.Drawing.Point(146, 615);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 27);
            this.label21.TabIndex = 54;
            this.label21.Text = "偏       航:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Khaki;
            this.label22.Location = new System.Drawing.Point(139, 642);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 56);
            this.label22.TabIndex = 53;
            this.label22.Text = "0.00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Snow;
            this.label19.Location = new System.Drawing.Point(20, 503);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 27);
            this.label19.TabIndex = 52;
            this.label19.Text = "爬  升 率:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(7, 544);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 56);
            this.label20.TabIndex = 51;
            this.label20.Text = "0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Snow;
            this.label13.Location = new System.Drawing.Point(139, 544);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 56);
            this.label13.TabIndex = 48;
            this.label13.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Snow;
            this.label14.Location = new System.Drawing.Point(146, 398);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 27);
            this.label14.TabIndex = 47;
            this.label14.Text = "地面速度:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label15.Location = new System.Drawing.Point(139, 425);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 56);
            this.label15.TabIndex = 46;
            this.label15.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Snow;
            this.label16.Location = new System.Drawing.Point(144, 503);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 27);
            this.label16.TabIndex = 45;
            this.label16.Text = "空中速度:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(7, 424);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 56);
            this.label11.TabIndex = 44;
            this.label11.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Snow;
            this.label12.Location = new System.Drawing.Point(20, 615);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 27);
            this.label12.TabIndex = 43;
            this.label12.Text = "航点距离:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Snow;
            this.label9.Location = new System.Drawing.Point(7, 642);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 56);
            this.label9.TabIndex = 42;
            this.label9.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Snow;
            this.label10.Location = new System.Drawing.Point(20, 397);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 27);
            this.label10.TabIndex = 41;
            this.label10.Text = "气压高度:";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(271, 0);
            this.gmap.Margin = new System.Windows.Forms.Padding(4);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(929, 791);
            this.gmap.TabIndex = 25;
            this.gmap.Zoom = 10D;
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            this.gmap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseMove);
            // 
            // hx_Control1
            // 
            this.hx_Control1.Location = new System.Drawing.Point(3, 264);
            this.hx_Control1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hx_Control1.Name = "hx_Control1";
            this.hx_Control1.Size = new System.Drawing.Size(127, 131);
            this.hx_Control1.TabIndex = 20;
            this.hx_Control1.Text = "hx_Control1";
            // 
            // att_Control1
            // 
            this.att_Control1.Location = new System.Drawing.Point(0, 0);
            this.att_Control1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.att_Control1.Name = "att_Control1";
            this.att_Control1.Size = new System.Drawing.Size(264, 281);
            this.att_Control1.TabIndex = 19;
            this.att_Control1.Text = "attitudeIndicatorInstrumentControl1";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_main.Controls.Add(this.tabPage_rxtx);
            this.tabControl_main.Controls.Add(this.tabPage_set);
            this.tabControl_main.Controls.Add(this.tabPage1);
            this.tabControl_main.Controls.Add(this.tabPage2);
            this.tabControl_main.Controls.Add(this.tabPage3);
            this.tabControl_main.Controls.Add(this.tabPage4);
            this.tabControl_main.Controls.Add(this.tabPage5);
            this.tabControl_main.Controls.Add(this.tabPage6);
            this.tabControl_main.Controls.Add(this.tabPage7);
            this.tabControl_main.Location = new System.Drawing.Point(13, -1);
            this.tabControl_main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1208, 860);
            this.tabControl_main.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1422, 803);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMOV地面站V1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip_secMapCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Commands)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage_rxtx.ResumeLayout(false);
            this.tabPage_rxtx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_comname;
        public System.Windows.Forms.Label label1;
        //  private AxiProfessionalLibrary.AxiSevenSegmentClockSMPTEX axiSevenSegmentClockSMPTEX1;
        //private AxisDigitalLibrary.AxiLedRectangleX axiLedRectangleX2;
        private System.Windows.Forms.CheckBox chackbox2;
        private System.Windows.Forms.CheckBox checkBox1;
        // private AxisDigitalLibrary.AxiLedRectangleX axiLedRectangleX1;
        public System.Windows.Forms.Button btn_com_open;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonLoadOffMaps;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_secMapCtrl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 清除任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 写入当前航点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为家ToolStripMenuItem;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerReplay;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelbRoutePlanStatus;
        private System.Windows.Forms.Button buttonClearWP;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonPlanningwp;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label labelDist2Home;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label labelsecLAT;
        private System.Windows.Forms.Label labelsecLOG;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxHomeALT;
        private System.Windows.Forms.TextBox textBoxHomeLOG;
        private System.Windows.Forms.TextBox textBoxHomeLAT;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button buttonwritewp;
        private System.Windows.Forms.Button buttonreadwp;
        public GMap.NET.WindowsForms.GMapControl gmap_setairway;
        private System.Windows.Forms.TabPage tabPage_set;
        private System.Windows.Forms.TabPage tabPage_rxtx;
        public System.Windows.Forms.Label labelSatelnum;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label labelMapProvider;
        private System.Windows.Forms.Label labelmainLAT;
        private System.Windows.Forms.Label labelmainLOG;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public GMap.NET.WindowsForms.GMapControl gmap;
        public AvionicsInstrumentControlDemo.HeadingIndicatorInstrumentControl hx_Control1;
        public AvionicsInstrumentControlDemo.AttitudeIndicatorInstrumentControl att_Control1;
        public System.Windows.Forms.TabControl tabControl_main;
        private AvionicsInstrumentControlDemo.VerticalSpeedIndicatorInstrumentControl verticalSpeedIndicatorInstrumentControl1;
        private System.Windows.Forms.DataGridView Commands;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Command;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Param4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alt;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewImageColumn Up;
        private System.Windows.Forms.DataGridViewImageColumn Down;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dist;
        private System.Windows.Forms.DataGridViewTextBoxColumn AZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox alt_warn;
        private System.Windows.Forms.Button flybutton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button landbutton;
        private System.Windows.Forms.Button autobutton;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttondisarm;
        private System.Windows.Forms.TextBox alttextBox;
        private System.Windows.Forms.Label labearmed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label flymode;
        private System.Windows.Forms.Button stabilizebutton;
        //private AxisAnalogLibrary.AxiAnalogDisplayX axiAnalogDisplayX1;
    }
}

