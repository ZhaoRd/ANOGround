using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms;
using ANOGround.GmapClass;
using GeoUtility;
using GeoUtility.GeoSystem;
using ANOGround;
using System.Runtime.InteropServices;
using System.Media;
using System.Diagnostics;
using ANOGround.Utilities;
using ANOGround.Comms;
using ANOGround.FlightPlanner;
using ANOGround.Controls;
using System.Collections;
using ANOGround.mavlink;
//***************************************************//
//**阿木社区编写(AMOV AUTO),玩也要玩的专业！
//** www.amovauto.com
//***本代码仅供参考，如有疑问请上社区论坛或者QQ群询问//

namespace ANOGround
{
    public partial class Form1 : Form
    {
        //进程之间传送数据
        const int WM_COPYDATA = 0x004A;
        /// <summary>
        ///
        /// </summary>
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public enum altmode
        {
            Relative = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT,
            Absolute = MAVLink.MAV_FRAME.GLOBAL,
            Terrain = MAVLink.MAV_FRAME.GLOBAL_TERRAIN_ALT
        }

        /// <summary>
        /// enum of firmwares
        /// </summary>
        public enum Firmwares
        {
            ArduPlane,
            ArduCopter2,
            ArduRover,
            Ateryx,
            ArduTracker,
            Gymbal,
            PX4
        }


        //*************阿木社区编写(AMOV AUTO)*******************//
        //mavlinkinterface接口实例化，这个成员变量包含了全部的mavlink协议操作
        public static MAVLinkInterface comPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if (_comPort == value)
                    return;
                //_comPort = value;//(目前注释这些方法，这个是如果com口有变动，会从新刷新mavlink数据)
                //_comPort.MavChanged -= instance.comPort_MavChanged;
                //_comPort.MavChanged += instance.comPort_MavChanged;
                //instance.comPort_MavChanged(null, null);
            }
        }
        static MAVLinkInterface _comPort = new MAVLinkInterface();

        public static Form1 instance = null;
        public static string comPortName = "";
        DateTime connecttime = DateTime.Now;
        DateTime nodatawarning = DateTime.Now;
        DateTime OpenTime = DateTime.Now;
        //串口读写线程,这个线程是读取飞控的线程
        Thread serialreaderthread;
        /// controls the main serial reader thread
        bool serialThread = false;
        //数据显示线程，从comPort.MAVlist.GetMAVStates的数据缓冲区读取数据显示
        Thread readcomdisplayThread;
        altmode currentaltmode = altmode.Relative;
        
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="lpClassName">指向一个指定了窗口类名</param>
        /// <param name="lpWindowName">指向一个指定了窗口名</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        /// <summary>
        /// 全局标志位变量表示逻辑处于哪种状态
        /// </summary>
        GBL_FLAG gbl_flag;
        /// <summary>
        /// 航路规划层，用于标记设定航点和预定航线
        /// </summary>
        GMapOverlay markersOverlay_sec;
        /// <summary>
        /// 实际飞行路径层
        /// </summary>
        GMapOverlay realRouteOverlay_sec;
        /// <summary>
        /// 实际飞行路径层
        /// </summary>
        GMapOverlay realRouteOverlay;
        GMarkerGoogle realRoutemarker;
        /// <summary>
        /// 飞行器飞行动画层
        /// </summary>
        /// 规划航点队列，包含了全部规划航点信息。航点0为家
        /// </summary>
        /// totalWPlist
        public static List<PointLatLngAlt> totalWPlist = new List<PointLatLngAlt>();
        /// <summary>
        /// 用于计算地图上两点距离的临时坐标变量
        /// </summary>
        PointLatLngAlt tmp_point_4_calc = new PointLatLngAlt();
        /// 当前在地图上鼠标所指的位置
        /// </summary>
        PointLatLng currentPosition = new PointLatLng();
        /// <summary>
        /// 家坐标
        /// </summary>
        PointLatLngAlt homePos = new PointLatLngAlt();
        /// <summary>
        /// 生效航点标记
        /// </summary>
        GMapMarker actWP_marker;
        /// <summary>
        /// 航点索引
        /// </summary>
        public static int actWP_index;
        /// <summary>
        /// 音频alarm
        /// </summary>
        SoundPlayer alarmSound = new SoundPlayer(Properties.Resources.alarm);
        /// <summary>
        /// 音频didi
        /// </summary>
        SoundPlayer didiSound = new SoundPlayer(Properties.Resources.didi);
        /// <summary>
        /// 提供一组方法和属性，可用于准确地测量运行时间
        /// </summary>
        private Stopwatch timer = new Stopwatch();

        MAVLink.mavlink_rc_channels_override_t rc_override1;

        private StringBuilder strbuilder = new StringBuilder();
        //*************************MAVLINK解析包 的引用*****************************
        MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();
        //*************************创建一个读串口对象*******************************
        UpdateComUiThread readcomdisplay;

        //*************************航点规划初始化类*********************************
        PlannParameInit plannparameinit = new PlannParameInit();
        Hashtable param = new Hashtable();//参数表哈希表
        private System.Timers.Timer gmapshowtimer;//gmap地图显示定时是，设置定时更新地图显示
        private double currentlat_value;//实时GPS坐标，用于地图显示
        private double currentlon_value;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scan_com();//扫描可用串口
            tabControl_main.SelectedIndex = 0;
            //************************************MAVLINK显示项目*****************************************

            gbl_flag.portListening = false;
            gbl_flag.portClosing = false;
            gbl_flag.nothing = true;//既不是飞行也不是数据回放
            gbl_flag.flight = false;
            gbl_flag.repaly = false;
            plannparameinit.updateCMDParams(Command);

            gmapshowtimer = new System.Timers.Timer(2000);//实例化Timer类，设置间隔时间为2000毫秒
            gmapshowtimer.Elapsed += new System.Timers.ElapsedEventHandler(gmaptimeout);//到达时间的时候执行地图更新
            gmapshowtimer.AutoReset = true;
            gmapshowtimer.Enabled = true;//使能定时器
            Commands.AllowUserToAddRows = false;
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            //************************************主界面GMAP地图的加载项目*****************************************
            //gmap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;//设置为卫星必应地图                   得找王博要哪个可以生成离线地图(既有高德卫星还有高德地图，定位准确的)的.core
            gmap.MapProvider = GMap.NET.MapProviders.AMapProvider.Instance;
            labelMapProvider.Text = gmap.MapProvider.Name;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;//设置为在线或离线地图

            gmap.CacheLocation = @"F:\好好做吧\阿木_da\离线地图保存";//使能离线地图
            gmap.DragButton = System.Windows.Forms.MouseButtons.Left;//左键拖拽地图

            //创建实时航路层，用于显示实时航线
            realRouteOverlay = new GMapOverlay("realroute");
            gmap.Overlays.Add(realRouteOverlay);
        }
        private void gmap_setairway_Load(object sender, EventArgs e)
        {
            //************************************航线规划GMAP地图的加载项目*****************************************
            //创建一个marker层，用于标记航点
            markersOverlay_sec = new GMapOverlay("markers_sec");
            gmap_setairway.Overlays.Add(markersOverlay_sec);

            //创建实时航路层，用于显示实时航线
            realRouteOverlay_sec = new GMapOverlay("realroute_sec");
            gmap_setairway.Overlays.Add(realRouteOverlay_sec);

            //地图初始化
            gmap_setairway.MapProvider = gmap.MapProvider; //设置为卫星必应地图
            gmap_setairway.ShowCenter = false; //不显示中心十字点
            gmap_setairway.DragButton = System.Windows.Forms.MouseButtons.Left; //左键拖拽地图   
        }

        private void scan_com()//对串口进行扫描
        {
            string[] ports = SerialPort.GetPortNames();//返回可以用的串口
            Array.Sort(ports);

            if (ports.Length==0)
            {
                return;
            }

            comboBox_comname.Items.AddRange(ports);
            comboBox_comname.SelectedIndex = 0;
            comboBox_baudrate.SelectedIndex = 4;
        
            //comboBox_comname.Text.Trim();
            if ((ports.Length > 0) == false)
            {
                comboBox_comname.Text = "None";
            }
        }
        private void button_ReFresh_Click(object sender, EventArgs e)
        {
            if (comPort.BaseStream.IsOpen) { }
            else
            {
                comboBox_comname.Items.Clear();
                scan_com();
            }
        }

        public void doConnect(MAVLinkInterface comPort, string portname, string baud)
        {
            bool skipconnectcheck = false;
            comPort.BaseStream = new SerialPort();
            // Tell the connection UI that we are now connected.
            //_connectionControl.IsConnected(true);

            // Here we want to reset the connection stats counter etc.
            //this.ResetConnectionStats();
            comPort.MAV.cs.ResetInternals();//初始化接口
            comPort.BaseStream.PortName = portname;
            comPort.BaseStream.BaudRate = int.Parse(baud);
            //     prevent serialreader from doing anything
            comPort.giveComport = true;
            if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
            {
                comPort.BaseStream.DtrEnable = false;
                comPort.BaseStream.RtsEnable = false;
                comPort.BaseStream.toggleDTR();
            }
            comPort.giveComport = false;
            connecttime = DateTime.Now;

            //     do the connect
            comPort.Open(false, skipconnectcheck);
            if (!comPort.BaseStream.IsOpen)
            {
                try
                {
                    comPort.Close();
                }
                catch
                {
                }
                return;
            }
            else
            {
                ;
            }

            //     get all mavstates
            //var list = comPort.MAVlist.GetMAVStates();

            //     get all the params
            //foreach (var mavstate in list)
            //{
            //  comPort.sysidcurrent = mavstate.sysid;
            // comPort.compidcurrent = mavstate.compid;
            // comPort.getParamList();
            // }

            //     set to first seen
            //comPort.sysidcurrent = list[0].sysid;
            //comPort.compidcurrent = list[0].compid;
        }



        private void btn_com_open_Click(object sender, EventArgs e)
        {

            DisReFresh();
            if (comPort.BaseStream.IsOpen)
            {
                gbl_flag.portClosing = true;
                while (!gbl_flag.portListening) Application.DoEvents();
                comPort.BaseStream.Close();
                gbl_flag.portListening = false;
                comboBox_comname.Enabled = true;
                comboBox_baudrate.Enabled = true;
                btn_com_open.Text = "建立通信";
            }
            else
            {
                if ((comPort.BaseStream.PortName != null) && (comPort.BaseStream.PortName != "None"))
                {

                    try
                    {
                        doConnect(comPort, comboBox_comname.Text.Trim(), comboBox_baudrate.Text.Trim());
                        // setup main serial reader
                        serialreaderthread = new Thread(SerialReader)
                        {
                            IsBackground = true,
                            Name = "Main display",
                            Priority = ThreadPriority.Normal
                        };
                        serialreaderthread.Start();//启动数据读线程

                        readcomdisplay = new UpdateComUiThread(comPort);//实例化读串口对象
                        //在readcomdisplay对象的readmavlinkThread(委托)对象上搭载一个方法，在线程中调用readmavlinkThread对象时相当于调用了这个方法。  
                        readcomdisplay.readmavlinkThread = new UpdateComUiThread.readmavlink(refreshLabMessage1);

                        //创建一个无参数的线程,这个线程执行TestClass类中的testFunction方法。  
                        readcomdisplayThread = new Thread(new ThreadStart(readcomdisplay.readmavlinkdelegate))
                        {
                            IsBackground = true,
                            Name = "Main Serial reader",
                            Priority = ThreadPriority.Lowest
                        };
                        //启动显示线程，启动之后线程才开始执行  
                        readcomdisplayThread.Start();


                    }
                    catch (Exception ex)
                    {
                        //捕获到异常信息
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请检出串口配置", "提示");
                }
                if (comPort.BaseStream.IsOpen)
                {
                    comboBox_comname.Enabled = false;
                    comboBox_baudrate.Enabled = false;
                    gbl_flag.portClosing = false;
                    btn_com_open.Text = "关闭通信";
                }
            }
        }


        private void DisReFresh()
        {
            //if (btn_com_open.Text == "关闭通信")
            //{
            //    button_ReFresh.Enabled = true;
            //    linkLabel1.Visible = false;
            //}
            //else
            //{
            //    button_ReFresh.Enabled = false;
            //    linkLabel1.Visible = true;
            //}

        }


        private void refreshLabMessage1(MAVState mavlinkpacket)
        {
            //判断该方法是否被主线程调用，当控件的InvokeRequired属性为ture时，说明是被主线程以外的线程调用。如果不加判断，会造成异常
            if (this.InvokeRequired)//
            {
                readcomdisplay.readmavlinkThread = new UpdateComUiThread.readmavlink(refreshLabMessage1);
                this.Invoke(readcomdisplay.readmavlinkThread, new MAVState[] { mavlinkpacket });
            }
            else
            {
                //  如果要在主线程更新MAVLINK的参数显示控件，请务必把上面的InvokeRequired判断加上！！，这里是放在readcomdisplayThread里面更新UI的                 
                currentlat_value = mavlinkpacket.cs.lat;
                currentlon_value = mavlinkpacket.cs.lng;
               
                //轮询飞控是否已经解锁标志位
                if (mavlinkpacket.cs.armed == true && (labearmed.Text.Equals( "已锁定(LOCK)") || labearmed.Text.Equals( "解锁失败")))
                {
                    labearmed.Text = "已解锁(UNLOCK)";
                    Console.WriteLine(Form1.comPort.MAV.cs.armed + "aaaaarmed");
                }
                if (mavlinkpacket.cs.armed == false && labearmed.Text.Equals("已解锁(UNLOCK)"))
                {
                    labearmed.Text = "已锁定(LOCK)";
                    Console.WriteLine(Form1.comPort.MAV.cs.armed + "lockaarmed");
                }
                Console.WriteLine(mavlinkpacket.cs._mode + "MODE");

              
                if (tabControl_main.SelectedIndex == 0)
                {
                    ////*****************************在主页地图上进行显示标注和定位***********************************
                    //******************进行姿态数据包的数学解析**************************************
                    att_Control1.SetAttitudeIndicatorParameters(mavlinkpacket.cs.pitch, -mavlinkpacket.cs.roll);
                    //***********************水平仪控件的成员变量PITCH  ROLL********************                  
                    //***********************磁罗盘控件的成员变量YAW********************
                    hx_Control1.SetHeadingIndicatorParameters((int)(mavlinkpacket.cs.yaw));
                    //******************气压数据包的数学解析***************************************
                    label1.Text = (mavlinkpacket.cs.press_abs).ToString("000.000" + "米");//在卫星地图内显示气压高度
                    //*******************地速包的数学解析**************************************
                    label15.Text = mavlinkpacket.cs.groundspeed.ToString("000.000");//在系统检测显示地速
                    label13.Text = mavlinkpacket.cs.airspeed.ToString("000.000");//在系统检测显示空速       
                }
            }
        }
        //GPS位置实时显示函数，为了降低CPU使用率，采取1200毫秒刷新的方式
        public void gmaptimeout(object source, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {

                    //*****************************在设置航点地图上进行显示标注和定位***********************************
                    gmap_setairway.Position = new PointLatLng(currentlat_value, currentlon_value);
                    realRoutemarker = new GMarkerGoogle(new PointLatLng(currentlat_value, currentlon_value), GMarkerGoogleType.green);
                    realRouteOverlay.Clear();
                    realRouteOverlay.Markers.Add(realRoutemarker);//增加新的定位点
                    gmap_setairway.Overlays.Add(realRouteOverlay);//控制器实时位置

                    //*****************************在主页地图上进行显示标注和定位***********************************
                    gmap.Position = new PointLatLng(currentlat_value, currentlon_value);
                    realRoutemarker = new GMarkerGoogle(new PointLatLng(currentlat_value, currentlon_value), GMarkerGoogleType.green);
                    realRouteOverlay.Clear();
                    realRouteOverlay.Markers.Add(realRoutemarker);//增加新的定位点
                    gmap.Overlays.Add(realRouteOverlay);//以下代码添加航线绘制
                }
                catch
                {
                }
            });

        }

        /// <summary>
        /// 在地图上添加一个航点标志
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="alt"></param>
        private void addpolygonmarker_sec(string tag, double lat, double lng, double alt, Color? color)
        {
            try
            {
                PointLatLng point = new PointLatLng(lat, lng);
                GMapMarkerWP m = new GMapMarkerWP(point, tag);
                m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                m.ToolTipText = "Alt: " + alt.ToString("0");
                m.Tag = tag;
                markersOverlay_sec.Markers.Add(m);//添加标志
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 根据航点的tag标志找到该航点的链表位置下标
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private int getWPindex(string tag)
        {
            for (int i = 0; i < totalWPlist.Count; i++)
            {
                if (totalWPlist[i].Tag == tag) return i;
                if (((totalWPlist[i].Tag == "0") || (totalWPlist[i].Tag == "H"))
                    && ((tag == "0") || (tag == "H")))
                    return 0;
            }
            return -1;
        }
        private void gmap_MouseMove(object sender, MouseEventArgs e)
        {

            PointLatLng point = gmap.FromLocalToLatLng(e.X, e.Y);
            labelmainLAT.Text = point.Lat.ToString("000.0000000");
            labelmainLOG.Text = point.Lng.ToString("000.0000000");
        }
        private void gmap_setairway_OnMarkerEnter(GMapMarker item)
        {
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem3.Enabled = true;
            //进入航点区域
            gbl_flag.markerentered = true;
            //记录进入的航点，作为当前活动航点
            actWP_marker = item;
        }

        private void gmap_setairway_OnMarkerLeave(GMapMarker item)
        {
            //如果鼠标没有在某个航点的上方，则点击鼠标右键时进制删除航点和修改高度
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem3.Enabled = false;
            //没有进入航点局域
            gbl_flag.markerentered = false;
        }
        private void gmap_setairway_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = gmap_setairway.FromLocalToLatLng(e.X, e.Y);
            double current2home_lng_m;
            double current2home_lat_m;
            double current2home_m;
            string NS;
            string WE;
            //鼠标移动时，在地图左上角显示当前坐标和距离HOME的距离
            labelsecLAT.Text = point.Lat.ToString("000.0000000");
            labelsecLOG.Text = point.Lng.ToString("000.0000000");
            //若有航点，则在鼠标移动时显示当前鼠标位置与第一个航点之间的距离
            if (totalWPlist.Count > 0)
            {
                //纬度上的距离（即东西距离）
                tmp_point_4_calc.Lng = totalWPlist[0].Lng;
                tmp_point_4_calc.Lat = point.Lat;
                current2home_lat_m = totalWPlist[0].GetDistance(tmp_point_4_calc);
                if (point.Lat > totalWPlist[0].Lat) NS = "N";
                else NS = "S";
                //经度上的距离（即南北距离）
                tmp_point_4_calc.Lng = point.Lng;
                tmp_point_4_calc.Lat = totalWPlist[0].Lat;
                current2home_lng_m = totalWPlist[0].GetDistance(tmp_point_4_calc);
                if (point.Lng > totalWPlist[0].Lng) WE = "E";
                else WE = "W";
                //直线距离
                tmp_point_4_calc.Lat = point.Lat;
                current2home_m = totalWPlist[0].GetDistance(tmp_point_4_calc);
                //显示
                labelDist2Home.Text = current2home_m.ToString("0") + " (" + NS + current2home_lat_m.ToString("0")
                    + "," + WE + current2home_lng_m.ToString("0") + ")";
            }
            //如果是在航点规划状态，则若某个航点被选(即在某个航点上点击了鼠标左键)，则可以被拖动
            if (gbl_flag.bRoutePlan)
            {
                if (gbl_flag.markerselected)//航点被选
                {
                    if (actWP_index == 0)
                    {//更新坐标更改
                        //textBoxHomeLAT.Text = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
                        //textBoxHomeLOG.Text = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
                        ////该航点的GPS坐标随着鼠标位置而变化
                        //totalWPlist[actWP_index].Lat = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat;
                        //totalWPlist[actWP_index].Lng = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng;
                        //actWP_marker.Position = gmap_setairway.FromLocalToLatLng(e.X, e.Y);
                    }
                    else
                    {
                        //该航点的GPS坐标随着鼠标位置而变化
                        totalWPlist[actWP_index].Lat = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat;
                        totalWPlist[actWP_index].Lng = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng;
                        actWP_marker.Position = gmap_setairway.FromLocalToLatLng(e.X, e.Y);
                        //坐标更具鼠标移动变化 而 变化
                        Commands.Rows[actWP_index -1].Cells[5].Value = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat;
                        Commands.Rows[actWP_index -1].Cells[6].Value = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng;
                    }
                  
                }
                else
                {
                }
            }
        }
        private void gmap_setairway_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)//点击鼠标左键
            {
                if (gbl_flag.bRoutePlan)//若是航点规划状态，则可以修改航点。以后要考虑在线修改
                {
                    //如果在航点处，则标记航点被选，且给出航点在航点表中的位置
                    if (gbl_flag.markerentered)
                    {
                        gbl_flag.markerselected = true;
                        //先找到航点链表中的相应航点下标
                        actWP_index = getWPindex(actWP_marker.Tag.ToString());// 总报错需检查
                    }
                }
            }
            if (e.Button == MouseButtons.Right)//鼠标右键出菜单
            {
                currentPosition = gmap_setairway.FromLocalToLatLng(e.X, e.Y);
                if (!gbl_flag.bRoutePlan)
                {
                    toolStripMenuItem2.Enabled = false;
                    toolStripMenuItem3.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 默认航行速度
        /// </summary>
        public const int default_WP_spd = 1;//[knot]  /////////////////////////////////////////////////////////////这段代码暂且这么写
        public const int default_WP_alt = 20;
        private void gmap_setairway_MouseUp(object sender, MouseEventArgs e)
        {

            if ((e.Button == MouseButtons.Left))//点击鼠标左键
            {
                if (gbl_flag.bRoutePlan)//航点规划状态时：加航点
                {

                    if (e.Button == MouseButtons.Left)////////////有问题
                    {

                        if (gbl_flag.markerselected)//如果是移动航点，则不需要做增加航点的工作，只是重新画航线即可
                        {

                        }
                        else//如果是增加航点，则
                        {
                            if (totalWPlist.Count == 0)
                            {
                                totalWPlist.Add(new PointLatLngAlt(currentlat_value, currentlon_value, default_WP_alt, totalWPlist.Count.ToString()));///这里一定不能使用默认航速default_WP_spd
                                addpolygonmarker_sec("H", currentlat_value,currentlon_value, default_WP_alt, null);
                                textBoxHomeLAT.Text = currentlat_value.ToString();
                                textBoxHomeLOG.Text = currentlon_value.ToString();
                                textBoxHomeALT.Text = default_WP_alt.ToString();
                            }
                           
                                DataGridViewRow Row = new DataGridViewRow();
                                Row.CreateCells(Commands);
                                Row.Cells[0].Value = MAVLink.MAV_CMD.WAYPOINT.ToString();
                                Row.Cells[1].Value = 0;
                                Row.Cells[2].Value = 0;
                                Row.Cells[3].Value = 0;
                                Row.Cells[4].Value = 0;
                                Row.Cells[5].Value = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat;
                                Row.Cells[6].Value = gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng;
                                Row.Cells[7].Value = default_WP_alt;//默认高度20M                             
                                totalWPlist.Add(new PointLatLngAlt(gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat, gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng, default_WP_alt, totalWPlist.Count.ToString()));///这里一定不能使用默认航速default_WP_spd
                                Commands.Rows.Insert(totalWPlist.Count -2, Row);                                                                                                                                                                                  ///
                                addpolygonmarker_sec((totalWPlist.Count -1).ToString(), gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lat, gmap_setairway.FromLocalToLatLng(e.X, e.Y).Lng, default_WP_alt, null);
                          
                        }
                        ReDrawAllRoute();
                    }
                    else
                    {
                    }
                    ///////////////
                }
            }
            if (e.Button == MouseButtons.Right)//鼠标右键出菜单
            {
            }

            gbl_flag.markerselected = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //找到指定航点，并删除
            if (!gbl_flag.bRoutePlan) return;
            for (int i = 0; i < totalWPlist.Count; i++)
            {
                if (totalWPlist[i].Tag == actWP_marker.Tag.ToString())
                {
                    totalWPlist.RemoveAt(i);
                    break;
                }
            }
            ReDrawAllWP();//重画全部航点
            ReDrawAllRoute();//重画全部路径
        }
        private void button1_Click(object sender, EventArgs e)// 打开飞行数据库对所有飞控参数进行记录
        {
            ;
        }

        private void comboBox_baudrate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void altimeterInstrumentControl1_Click(object sender, EventArgs e)
        {

        }

        private void airSpeedIndicatorInstrumentControl1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            this.gmap.Zoom = trackBar1.Value;
            //var temp = this.gmap.Zoom;
            //trackBar1.Value = (int)temp;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonLoadOffMaps_Click(object sender, EventArgs e)
        {
            //我记得有一个叫做DIOLOG 调出离线地图
        }

        private void buttonSetHome_Click(object sender, EventArgs e)
        {
            if (gbl_flag.bRoutePlan)
            {
                if (textBoxHomeLAT.Text.Trim() != "" && textBoxHomeLOG.Text.Trim() != null)
                {
                    homePos.Lat = double.Parse(textBoxHomeLAT.Text);
                    homePos.Lng = double.Parse(textBoxHomeLOG.Text);
                    homePos.Alt = double.Parse(textBoxHomeALT.Text);
                    homePos.Tag = "H";
                    /////////////

                    if (totalWPlist.Count == 0)////////////////zhelizheli
                    {
                        totalWPlist.Add(new PointLatLngAlt(homePos.Lat, homePos.Lng, homePos.Alt, "H"));
                        addpolygonmarker_sec("H", homePos.Lat, homePos.Lng, homePos.Alt, null);//设为“新家”，下面要增加代码删除“旧家”
                    }
                    else
                    {
                        //////////删除第一个元素，再把新的H添加进来
                        totalWPlist.RemoveAt(0);
                        ///////////////
                        totalWPlist.Insert(0, homePos);//改为在之前插入
                        addpolygonmarker_sec("H", homePos.Lat, homePos.Lng, homePos.Alt, null);//设为“新家”，下面要增加代码删除“旧家”
                        ReDrawAllWP();//重画全部航点
                        ReDrawAllRoute();//重画全部路径
                    }


                }
                else
                {
                    MessageBox.Show("输入值不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);//当设置的TEXTBOX里面输入不符合航点信息的内容是 打印messagebox  增加程序的健壮性
                }

            }
            else
            {
                MessageBox.Show("非航点编辑状态：不能设置家", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonPlanningwp_Click(object sender, EventArgs e)
        {
            gbl_flag.bRoutePlan = !gbl_flag.bRoutePlan;
            if (gbl_flag.bRoutePlan)
            {
                labelbRoutePlanStatus.Text = "航点编辑中";
                toolStripMenuItem2.Enabled = true;
                buttonPlanningwp.Text = "退出航点规划";
                设为家ToolStripMenuItem.Enabled = true;
            }
            else
            {
                labelbRoutePlanStatus.Text = "已退出航点编辑";
                buttonPlanningwp.Text = "进入航点规划";
                设为家ToolStripMenuItem.Enabled = false;
            }
        }

        private void buttonPlanningwp_MouseHover(object sender, EventArgs e)//没用
        {

        }
        /// <summary>
        /// 在两个规划航点之间画一条直线路径
        /// </summary>
        /// <param name="point_start"></param>
        /// <param name="point_end"></param>
        private void DrawLineLinkTwoWP(PointLatLng point_start, PointLatLng point_end)
        {
            List<PointLatLng> points;
            GMapPolygon line;
            points = new List<PointLatLng>();
            points.Add(point_start);
            points.Add(point_end);
            line = new GMapPolygon(points, "");
            line.Stroke = new Pen(Color.Yellow, 4);
            markersOverlay_sec.Polygons.Add(line);
        }
        /// <summary>
        /// 画出连接全部航点的航路（直线型）
        /// </summary>
        private void ReDrawAllRoute()
        {
            //清除多边形
            markersOverlay_sec.Polygons.Clear();
            //然后重新画航点间直线
            for (int i = 0; i < totalWPlist.Count; i++)
            {
                if (i == totalWPlist.Count - 1)
                    //画最后一个航点到第一个航点的直线
                    DrawLineLinkTwoWP(totalWPlist[totalWPlist.Count - 1], totalWPlist[0]);
                else DrawLineLinkTwoWP(totalWPlist[i], totalWPlist[i + 1]);
                //else DrawLineLinkTwoRealFlyPoint(totalWPlist[i], totalWPlist[i + 1]);
            }
        }
        private void ReDrawAllWP()
        {
            //重新将各航点做标记，第一个航点为H，其它航点从1顺序编号
            for (int i = 0; i < totalWPlist.Count; i++)
            {
                totalWPlist[i].Tag = i.ToString();
            }
            //清除地图上的全部航点标志
            markersOverlay_sec.Markers.Clear();
            //重画全部航点
            for (int i = 0; i < totalWPlist.Count; i++)
            {
                addpolygonmarker_sec(totalWPlist[i].Tag, totalWPlist[i].Lat, totalWPlist[i].Lng, totalWPlist[i].Alt, null);
            }
        }

        private void 设为家ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gbl_flag.bRoutePlan)
            {
                homePos.Lat = currentPosition.Lat;
                homePos.Lng = currentPosition.Lng;
                homePos.Alt = 0;
                homePos.Tag = "H";
                /////////////

                if (totalWPlist.Count == 0)////////////////zhelizheli
                {
                    totalWPlist.Add(new PointLatLngAlt(homePos.Lat, homePos.Lng, homePos.Alt, "H"));
                    addpolygonmarker_sec("H", homePos.Lat, homePos.Lng, homePos.Alt, null);//设为“新家”，下面要增加代码删除“旧家”
                }
                else
                {
                    //////////删除第一个元素，再把新的H添加进来
                    totalWPlist.RemoveAt(0);
                    ///////////////
                    totalWPlist.Insert(0, homePos);//改为在之前插入
                    addpolygonmarker_sec("H", homePos.Lat, homePos.Lng, homePos.Alt, null);//设为“新家”，下面要增加代码删除“旧家”
                    ReDrawAllWP();//重画全部航点
                    ReDrawAllRoute();//重画全部路径
                }
            }
        }

        private void gmap_setairway_OnMapDrag()
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    gmap.MapProvider = GMap.NET.MapProviders.AMapProvider.Instance;
                    gmap_setairway.MapProvider = gmap.MapProvider;
                    labelMapProvider.Text = gmap.MapProvider.Name;
                    break;
                case 1:
                    gmap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;
                    gmap_setairway.MapProvider = gmap.MapProvider;
                    labelMapProvider.Text = gmap.MapProvider.Name;
                    break;
                default:
                    gmap.MapProvider = GMap.NET.MapProviders.AMapProvider.Instance;
                    gmap_setairway.MapProvider = gmap.MapProvider;
                    labelMapProvider.Text = gmap.MapProvider.Name;
                    break;
            }
        }

        private void buttonClearWP_Click(object sender, EventArgs e)
        {
            if (actWP_marker != null)
            {
                totalWPlist.Clear();
                Commands.Rows.Clear();//清除航点集合
                ReDrawAllWP();
                ReDrawAllRoute();
                actWP_marker = null;
                labelDist2Home.Text = "dis";
                gbl_flag.markerentered = false;
                gbl_flag.markerselected = false;
            }
        }


        /// <summary>
        /// 在两个实时飞行点之间画一条直线，用于画出实时航路
        /// </summary>
        /// <param name="point_start"></param>
        /// <param name="point_end"></param>
        private void DrawLineLinkTwoRealFlyPoint(PointLatLng point_start, PointLatLng point_end)
        {
            List<PointLatLng> points;
            GMapPolygon line;
            points = new List<PointLatLng>();
            points.Add(point_start);
            points.Add(point_end);
            line = new GMapPolygon(points, "");
            line.Stroke = new Pen(Color.Green, 2);
            realRouteOverlay.Polygons.Add(line);
        }

        ////*************有关于飞行器在地图上的显示*********************************
        ///// <summary>
        ///// 飞机当前的位置
        ///// </summary>
        //PointLatLngAlt realpos_now = new PointLatLngAlt();
        ///// <summary>
        ///// 上一次显示时的飞行位置
        ///// </summary>
        //PointLatLngAlt realpos_prev = new PointLatLngAlt();
        ///// <summary>
        ///// 本时段实时飞行路径起点
        ///// </summary>
        //PointLatLng realroute_start;
        ///// <summary>
        ///// 本时段实时飞行路径终点
        ///// </summary>
        //PointLatLng realroute_end;
        ///// <summary>
        ///// 当前实时飞行目标航点
        ///// </summary>
        //int real_tar_WP = 0;//默认当前目标航点
        //GMapMarker realVehicle;

        ///// <summary>
        ///// 飞行器在地图上的实时显示
        ///// </summary>        
        //private void SailDisplay()
        //{
        //    if (totalWPlist.Count < 1) return;
        //    if (gbl_flag.repaly)//模拟飞行显示
        //    {
        //        if (totalWPlist.Count == 1)//仅有一个设定航点，则飞机位于航点处
        //        {
        //            realpos_now.Lat = totalWPlist[0].Lat;
        //            realpos_now.Lng = totalWPlist[0].Lng;
        //            realpos_now.Alt = totalWPlist[0].Alt;
        //            realroute_start = realpos_now;
        //            real_tar_WP = 0;
        //        }
        //        else if (!gbl_flag.repaly)//非模拟飞行状态时，将飞机的当前位置设置为在航点0，下一个航点为1
        //        {
        //            realpos_now.Lat = totalWPlist[0].Lat;
        //            realpos_now.Lng = totalWPlist[0].Lng;
        //            realpos_now.Alt = totalWPlist[0].Alt;
        //            realroute_start = realpos_now;
        //            real_tar_WP = 1;
        //        }
        //        else //航行状态
        //        {
        //            //查找目标航点
        //            for (int i = real_tar_WP; i < totalWPlist.Count; i++)
        //            {
        //                if (totalWPlist[i].GetDistance(realpos_now) < 10.0)//[m]如果离某个航点非常近，则目标是下一个航点
        //                {
        //                    if (i == (totalWPlist.Count - 1)) real_tar_WP = 0;
        //                    else real_tar_WP = i + 1;
        //                    break;
        //                }
        //            }
        //            double tmp_angle = realpos_now.GetBearing(totalWPlist[real_tar_WP]);
        //            double tmp_delta_lat = 0.0001 * Math.Abs(Math.Cos(tmp_angle * Math.PI / 180));//每次移动0.0001(默认飞行速度约=10.0m/s)
        //            double tmp_delta_lng = 0.0001 * Math.Abs(Math.Sin(tmp_angle * Math.PI / 180));

        //            if (realpos_now.Lat > (totalWPlist[real_tar_WP].Lat + tmp_delta_lat)) realpos_now.Lat -= tmp_delta_lat;
        //            else if (realpos_now.Lat < (totalWPlist[real_tar_WP].Lat - tmp_delta_lat)) realpos_now.Lat += tmp_delta_lat;
        //            if (realpos_now.Lng > (totalWPlist[real_tar_WP].Lng + tmp_delta_lng)) realpos_now.Lng -= tmp_delta_lng;
        //            else if (realpos_now.Lng < (totalWPlist[real_tar_WP].Lng - tmp_delta_lng)) realpos_now.Lng += tmp_delta_lng;
        //            if (realpos_now.Alt > (totalWPlist[real_tar_WP].Alt + 1.0)) realpos_now.Alt -= 1.0;//[m/s]默认爬升率=1m/s
        //            else if (realpos_now.Alt < (totalWPlist[real_tar_WP].Alt - 1.0)) realpos_now.Alt += 1.0;//[m/s]爬升率 
        //        }
        //    }
        //    else//真实飞行状态
        //    {
        //        //if ((mavlinkpacketdispaly.GPS_value.lat> 20.0) && (mavlinkpacketdispaly.GPS_value.lon > 100.0))
        //        //{
        //        //    realpos_now.Lat = Convert.ToDouble(mavlinkpacketdispaly.GPS_value.lat) * 0.00001;
        //        //    realpos_now.Lng = Convert.ToDouble(mavlinkpacketdispaly.GPS_value.lon) * 0.00001;
        //        //}
        //        //else
        //        //{
        //        //realpos_now.Lat = homePos.Lat;
        //        //realpos_now.Lng = homePos.Lng;
        //        //}
        //        //realpos_now.Lat = mavlinkpacketdispaly.GPS_value.lat;
        //        //realpos_now.Lng = mavlinkpacketdispaly.GPS_value.lon;
        //        //realpos_now.Lat = (Int32)mavlinkpacketdispaly.GPS_value.lat / 10000000;
        //        //realpos_now.Lng = (Int32)mavlinkpacketdispaly.GPS_value.lon / 10000000;
        //    }

        //    //画出飞行动画
        //    realVehicleOverlay.Clear();//先清除上次画的动画
        //    float target_angle = (float)realpos_now.GetBearing(totalWPlist[real_tar_WP]);//计算目标点方向
        //    float cog_angle = (float)realpos_prev.GetBearing(realpos_now);//计算地速方向
        //    float heading_angle = target_angle;//机头朝向，应由自驾仪传感器给出
        //    float nav_angle = target_angle;//导航方向，应由自驾仪计算给出
        //    realVehicle = new GMapMarkerPlane(realpos_now, heading_angle, cog_angle, nav_angle, target_angle);//画动画
        //    realVehicleOverlay.Markers.Add(realVehicle);
        //    //画出实时飞行航路
        //    realroute_end = realpos_now;
        //    DrawLineLinkTwoRealFlyPoint(realroute_start, realroute_end);//画实时飞行航路
        //    realroute_start = realroute_end;//记录当前航点
        //    realpos_prev.Lat = realroute_end.Lat;//用于计算地速方向
        //    realpos_prev.Lng = realroute_end.Lng;

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            gbl_flag.repaly = true;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            //  SailDisplay();
        }


        private void SerialReader()//串口读写线程
        {
            if (serialThread == true)
                return;
            serialThread = true;
            bool armedstatus = false;

            while (serialThread)
            {
                if (comPort.BaseStream.IsOpen && comPort.BaseStream.BytesToRead > 0 &&
                          comPort.giveComport == false)
                {
                    try
                    {
                        comPort.readPacket();

                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                }
                else
                {
                    Thread.Sleep(5);
                }
            }
            Thread.Sleep(1); // was 5
        }
        //*************阿木社区编写(AMOV AUTO)*******************//
        //航点写入操作
        private void button4_Click(object sender, EventArgs e)
        {
            // check for invalid grid data验证航点的逻辑准确性
            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                for (int b = 0; b < Commands.ColumnCount - 0; b++)
                {
                    double answer;
                    if (b >= 1 && b <= 7)
                    {
                        if (!double.TryParse(Commands[b, a].Value.ToString(), out answer))
                        {
                            CustomMessageBox.Show("There are errors in your mission");
                            return;
                        }
                    }

                    if (alt_warn.Text == "")
                        alt_warn.Text = (0).ToString();

                    if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
                        continue;

                    byte cmd =
                        (byte)
                            (int)
                                Enum.Parse(typeof(MAVLink.MAV_CMD),
                                    Commands.Rows[a].Cells[Command.Index].Value.ToString(), false);

                    if (cmd < (byte)MAVLink.MAV_CMD.LAST &&
                        double.Parse(Commands[Alt.Index, a].Value.ToString()) < double.Parse(alt_warn.Text))
                    {
                        if (cmd != (byte)MAVLink.MAV_CMD.TAKEOFF &&
                            cmd != (byte)MAVLink.MAV_CMD.LAND &&
                            cmd != (byte)MAVLink.MAV_CMD.RETURN_TO_LAUNCH)
                        {
                            CustomMessageBox.Show("Low alt on WP#" + (a + 1) +
                                                  "\nPlease reduce the alt warning, or increase the altitude");
                            return;
                        }
                    }
                }
            }



            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue//新建航点写入对话框
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Sending WP's"
            };

            frmProgressReporter.DoWork += saveWPs;//航点写入函数
            frmProgressReporter.UpdateProgressAndStatus(-1, "Sending WP's");
            frmProgressReporter.RunBackgroundOperationAsync();
            frmProgressReporter.Dispose();
            this.Focus();
        }


        //*************阿木社区编写(AMOV AUTO)*******************//
        //航点写入操作，委托函数
        void saveWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            try
            {
                MAVLinkInterface port = Form1.comPort;//得到MAVLINK类

                if (!port.BaseStream.IsOpen)//判断有没有串口接入
                {
                    throw new Exception("Please connect first!");
                }

                Form1.comPort.giveComport = true;//com口占用标志，读线程失效
                int a = 0;
                // define the home point
                Locationwp home = new Locationwp();
                try
                {
                    home.id = (byte)MAVLink.MAV_CMD.WAYPOINT;//写入家的位置
                    home.lat = double.Parse(textBoxHomeLAT.Text.ToString());
                    home.lng = double.Parse(textBoxHomeLOG.Text.ToString());
                    home.alt = (float.Parse(textBoxHomeALT.Text.ToString()) / CurrentState.multiplierdist); // use saved home
                }
                catch
                {
                    throw new Exception("Your home location is invalid");
                }


                bool use_int = (port.MAV.cs.capabilities & MAVLink.MAV_PROTOCOL_CAPABILITY.MISSION_INT) > 0;
                // set wp total
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set total wps ");
                ushort totalwpcountforupload = (ushort)(Commands.Rows.Count + 1);
                if (port.MAV.apname == MAVLink.MAV_AUTOPILOT.PX4)
                {
                    totalwpcountforupload--;
                }
                //计算上报一共要上传的航点
                port.setWPTotal(totalwpcountforupload); // + home
                Console.WriteLine("上传航点个数" + totalwpcountforupload);
                // set home location - overwritten/ignored depending on firmware.
                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Set home");
                // upload from wp0
                a = 0;
                if (port.MAV.apname != MAVLink.MAV_AUTOPILOT.PX4)
                {
                    try
                    {//设置航点
                        var homeans = port.setWP(home, (ushort)a, MAVLink.MAV_FRAME.GLOBAL, 0, 1,true);
                        Console.WriteLine("家的位置返回值" + homeans);
                        Console.WriteLine("家的位置返回值" + use_int);
                        if (homeans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                        {
                            CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                            return;
                        }
                        a++;
                    }
                    catch (TimeoutException ex)
                    {
                        use_int = false;
                        // added here to prevent timeout errors
                        port.setWPTotal(totalwpcountforupload);
                        var homeans = port.setWP(home, (ushort)a, MAVLink.MAV_FRAME.GLOBAL, 0, 1, use_int);
                        if (homeans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                        {
                            CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
                            return;
                        }
                        a++;
                    }
                }
                else
                {
                    use_int = false;
                }

                // define the default frame.
                MAVLink.MAV_FRAME frame = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT;

                // get the command list from the datagrid
                var commandlist = GetCommandList();
           

                // process commandlist to the mav
                for (a = 1; a <= commandlist.Count; a++)
                {
                    var temp = commandlist[a - 1];

                    ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / Commands.Rows.Count,
                        "Setting WP " + a);

                    // make sure we are using the correct frame for these commands
                    if (temp.id < (ushort)MAVLink.MAV_CMD.LAST || temp.id == (ushort)MAVLink.MAV_CMD.DO_SET_HOME)
                    {
                        var mode = currentaltmode;

                        if (mode == altmode.Terrain)
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL_TERRAIN_ALT;
                        }
                        else if (mode == altmode.Absolute)
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL;
                        }
                        else
                        {
                            frame = MAVLink.MAV_FRAME.GLOBAL_RELATIVE_ALT;
                        }
                    }

                    // try send the wp
                    MAVLink.MAV_MISSION_RESULT ans = port.setWP(temp, (ushort)(a), frame, 0, 1, use_int);

                    // we timed out while uploading wps/ command wasnt replaced/ command wasnt added
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ERROR)
                    {
                        // resend for partial upload
                        port.setWPPartialUpdate((ushort)(a), totalwpcountforupload);
                        // reupload this point.
                        ans = port.setWP(temp, (ushort)(a), frame, 0, 1, use_int);
                    }

                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_NO_SPACE)
                    {
                        e.ErrorMessage = "Upload failed, please reduce the number of wp's";
                        return;
                    }
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_INVALID)
                    {
                        e.ErrorMessage =
                            "Upload failed, mission was rejected byt the Mav,\n item had a bad option wp# " + a + " " +
                            ans;
                        return;
                    }
                    if (ans == MAVLink.MAV_MISSION_RESULT.MAV_MISSION_INVALID_SEQUENCE)
                    {
                        // invalid sequence can only occur if we failed to see a response from the apm when we sent the request.
                        // or there is io lag and we send 2 mission_items and get 2 responces, one valid, one a ack of the second send

                        // the ans is received via mission_ack, so we dont know for certain what our current request is for. as we may have lost the mission_request

                        // get requested wp no - 1;
                        a = port.getRequestedWPNo() - 1;

                        continue;
                    }
                    if (ans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                    {
                        e.ErrorMessage = "Upload wps failed " + Enum.Parse(typeof(MAVLink.MAV_CMD), temp.id.ToString()) +
                                         " " + Enum.Parse(typeof(MAVLink.MAV_MISSION_RESULT), ans.ToString());
                        return;
                    }
                }

                port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(95, "Setting params");

                //// m
                //port.setParam("WP_RADIUS", float.Parse(TXT_WPRad.Text) / CurrentState.multiplierdist);

                //// cm's
                //port.setParam("WPNAV_RADIUS", float.Parse(TXT_WPRad.Text) / CurrentState.multiplierdist * 100.0);

                //try
                //{
                //    port.setParam(new[] { "LOITER_RAD", "WP_LOITER_RAD" },
                //        float.Parse(TXT_loiterrad.Text) / CurrentState.multiplierdist);
                //}
                //catch
                //{
                //}

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done.");
            }
            catch (Exception ex)
            {
                // log.Error(ex);
                Form1.comPort.giveComport = false;//com口释放标志，读线程运行
                throw;
            }

            Form1.comPort.giveComport = false;//com口释放标志，读线程运行
        }

        List<Locationwp> GetCommandList()
        {
            List<Locationwp> commands = new List<Locationwp>();

            for (int a = 0; a < Commands.Rows.Count - 0; a++)
            {
                var temp = DataViewtoLocationwp(a);

                commands.Add(temp);
            }

            return commands;
        }

        Locationwp DataViewtoLocationwp(int a)
        {
            Locationwp temp = new Locationwp();
            if (Commands.Rows[a].Cells[Command.Index].Value.ToString().Contains("UNKNOWN"))
            {
                temp.id = (byte)Commands.Rows[a].Cells[Command.Index].Tag;
            }
            else
            {
                temp.id =
                    (byte)
                        (int)
                            Enum.Parse(typeof(MAVLink.MAV_CMD), Commands.Rows[a].Cells[Command.Index].Value.ToString(),
                                false);
            }
            temp.p1 = float.Parse(Commands.Rows[a].Cells[Param1.Index].Value.ToString());

            temp.alt =
                (float)(double.Parse(Commands.Rows[a].Cells[Alt.Index].Value.ToString()) / CurrentState.multiplierdist);
            temp.lat = (double.Parse(Commands.Rows[a].Cells[Lat.Index].Value.ToString()));
            temp.lng = (double.Parse(Commands.Rows[a].Cells[Lon.Index].Value.ToString()));

            temp.p2 = (float)(double.Parse(Commands.Rows[a].Cells[Param2.Index].Value.ToString()));
            temp.p3 = (float)(double.Parse(Commands.Rows[a].Cells[Param3.Index].Value.ToString()));
            temp.p4 = (float)(double.Parse(Commands.Rows[a].Cells[Param4.Index].Value.ToString()));

            return temp;
        }

        private void buttonreadwp_Click(object sender, EventArgs e)
        {
            if (Commands.Rows.Count > 0)
            {
                if (CustomMessageBox.Show("This will clear your existing planned mission, Continue?", "Confirm",
                     MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }

                Commands.Rows.Clear();
                totalWPlist.Clear();
                Commands.Rows.Clear();//清除航点集合
                ReDrawAllWP();
                ReDrawAllRoute();
            }

            ProgressReporterDialogue frmProgressReporter = new ProgressReporterDialogue
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Receiving WP's"
            };

            frmProgressReporter.DoWork += getWPs;
            frmProgressReporter.UpdateProgressAndStatus(-1, "Receiving WP's");
            frmProgressReporter.RunBackgroundOperationAsync();
            frmProgressReporter.Dispose();
            this.Focus();
        }

        void getWPs(object sender, ProgressWorkerEventArgs e, object passdata = null)
        {
            List<Locationwp> cmds = new List<Locationwp>();

            try
            {
                MAVLinkInterface port = comPort;

                if (!port.BaseStream.IsOpen)
                {
                    throw new Exception("Please Connect First!");
                }

                comPort.giveComport = true;

                param = port.MAV.param;

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(0, "Getting WP count");

                if (port.MAV.apname == MAVLink.MAV_AUTOPILOT.PX4)
                {
                    try
                    {
                        cmds.Add(port.getHomePosition());
                    }
                    catch (TimeoutException ex)
                    {
                        // blank home
                        cmds.Add(new Locationwp() { id = (byte)MAVLink.MAV_CMD.WAYPOINT });
                    }
                }
                int cmdcount = port.getWPCount();
                Console.WriteLine("读出航点个数"+cmdcount);
                for (ushort a = 0; a < cmdcount; a++)
                {
                    if (((ProgressReporterDialogue)sender).doWorkArgs.CancelRequested)
                    {
                        ((ProgressReporterDialogue)sender).doWorkArgs.CancelAcknowledged = true;
                        throw new Exception("Cancel Requested");
                    }


                    ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(a * 100 / cmdcount, "Getting WP " + a);
                    cmds.Add(port.getWP(a));
                }

                port.setWPACK();

                ((ProgressReporterDialogue)sender).UpdateProgressAndStatus(100, "Done");


            }
            catch
            {
                throw;
            }
            comPort.giveComport = false;
            processToScreen(cmds, true);
        }
        /// <summary>
        /// Processes a loaded EEPROM to the map and datagrid
        /// </summary>
        void processToScreen(List<Locationwp> cmds, bool append = false)
        {
            // mono fix
            Commands.CurrentCell = null;
            while (Commands.Rows.Count > 0 && !append)
                Commands.Rows.Clear();

            if (cmds.Count == 0)
            {
                return;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                try
                {

                    int i = Commands.Rows.Count - 1;
                    foreach (Locationwp temp in cmds)
                    {
                        DataGridViewRow Row = new DataGridViewRow();
                        Row.CreateCells(Commands);
                        //Console.WriteLine("FP processToScreen " + i);
                        if (temp.id == 0 && i != 0) // 0 and not home
                            break;
                        if (temp.id == 255 && i != 0) // bad record - never loaded any WP's - but have started the board up.
                            break;
                        foreach (object value in Enum.GetValues(typeof(MAVLink.MAV_CMD)))
                        {
                            if ((int)value == temp.id)
                            {
                                Row.Cells[0].Value = value.ToString();

                                break;
                            }
                        }

                        Row.Cells[1].Value = cmds.Count.ToString();
                        Row.Cells[2].Value = 0;
                        Row.Cells[3].Value = 0;
                        Row.Cells[4].Value = 0;
                        Row.Cells[5].Value = temp.lat.ToString();
                        Row.Cells[6].Value = temp.lng.ToString();
                        Row.Cells[7].Value = temp.lat.ToString();//默认高度20M
                        Commands.Rows.Add(Row);
                        totalWPlist.Add(new PointLatLngAlt(temp.lat, temp.lng, temp.lat, totalWPlist.Count.ToString()));///这里一定不能使用默认航速default_WP_spd
                        if (totalWPlist.Count == 1)
                        {
                            addpolygonmarker_sec("H", temp.lat, temp.lng, temp.lat, null); 
                        }
                        else
                        {
                            addpolygonmarker_sec((totalWPlist.Count - 1).ToString(), temp.lat, temp.lng, temp.lat, null);
                        }
                    }
                    ReDrawAllRoute();
               

                }
                catch
                {
                    throw;
                }

            });
        }
        //功能:一键起飞到固定高度
        //说明:在指导(GUIDE)模式下，发送了takeoff指令，飞机飞到指定高度
        private void flybutton_Click(object sender, EventArgs e)
        {
            stabilizemode();
            System.Threading.Thread.Sleep(100);   
            if (Form1.comPort.doARM(true))
            {
                Form1.comPort.setMode(new MAVLink.mavlink_set_mode_t
                {
                    //使能了用户模式选择
                    base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED,
                    //在指导模式下custom_mode = 4 标示指导模式
                    custom_mode = 4,
                    target_system = Form1.comPort.MAV.sysid
                });
                System.Threading.Thread.Sleep(300);
                bool ans =Form1.comPort.doCommand(MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0,(float)(double.Parse(alttextBox.Text)));
                if (ans == true) { flymode.Text = "GUIDE"; }
            }
        }
        

        private void landbutton_Click(object sender, EventArgs e)
        {
            stabilizemode();
            System.Threading.Thread.Sleep(100);
            Form1.comPort.setMode(new MAVLink.mavlink_set_mode_t
            {
                //使能了用户模式选择
                base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED,
                //在着陆模式下custom_mode = 9 标示着陆模式
                custom_mode = 9,
                target_system = Form1.comPort.MAV.sysid
            });
            flymode.Text = "LAND";
            System.Threading.Thread.Sleep(300);
        }

        private void buttondisarm_Click(object sender, EventArgs e)
        {
            bool ans = Form1.comPort.doARM(!Form1.comPort.MAV.cs.armed);
            Console.WriteLine(Form1.comPort.MAV.cs.armed + "click");
            if(ans != true)
            {
                labearmed.Text = "解锁失败";
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void autobutton_Click(object sender, EventArgs e)
        {
            stabilizemode();
            System.Threading.Thread.Sleep(100);
                Form1.comPort.setMode(new MAVLink.mavlink_set_mode_t
                {
                    //使能了用户模式选择
                    base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED,
                    //在指导模式下custom_mode = 3标示指导模式
                    custom_mode = 3,
                    target_system = Form1.comPort.MAV.sysid
                });
                flymode.Text = "AUTO";
                System.Threading.Thread.Sleep(300);
              
            
        }
        private void stabilizemode()
        {
        Form1.comPort.setMode(new MAVLink.mavlink_set_mode_t
                {
                    //使能了用户模式选择
                    base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED,
                    //在指导模式下custom_mode = 0标示指导模式
                    custom_mode = 0,
                    target_system = Form1.comPort.MAV.sysid
                });
        }
        private void stabilizebutton_Click(object sender, EventArgs e)
        {
           
                Form1.comPort.setMode(new MAVLink.mavlink_set_mode_t
                {
                    //使能了用户模式选择
                    base_mode = (byte)MAVLink.MAV_MODE_FLAG.CUSTOM_MODE_ENABLED,
                    //在指导模式下custom_mode = 0标示指导模式
                    custom_mode = 0,
                    target_system = Form1.comPort.MAV.sysid
                });
                flymode.Text = "Stabilize";
                System.Threading.Thread.Sleep(300);
        }

    private void write_RCoverride()
{
            MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();

            rc.target_component = Form1.comPort.MAV.compid;
            rc.target_system = Form1.comPort.MAV.sysid;

            rc.chan1_raw = 1600;
            rc.chan2_raw = 0;
            rc.chan3_raw = 1540;
            rc.chan4_raw = 0;
            rc.chan5_raw = 0;
            rc.chan6_raw = 0;
            rc.chan7_raw = 0;
            rc.chan8_raw = 0;

            try
            {
                Form1.comPort.sendPacket(rc, rc.target_system, rc.target_component);
                System.Threading.Thread.Sleep(20);
            }
            catch (Exception ex)
            {
                //log.Error(ex);
            }	
}

        private void button10_Click(object sender, EventArgs e)
        {
            write_RCoverride(); 
        }
    }
}

