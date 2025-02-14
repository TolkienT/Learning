using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TM200Demo
{
    public struct DevGPIO
    {
        /// <summary>
        /// 1.主动模式 0.被动模式
        /// </summary>
        public byte initiative_or_passivity;
        /// <summary>
        /// 1.主动模式下才有触发延迟
        /// </summary>
        public uint auto_delay_time;
        /// <summary>
        /// 0.被动模式才有输入1 1.打开  0.关闭
        /// </summary>
        public byte passivity_input1;
        /// <summary>
        /// 0.被动模式才有输入2 1.打开  0.关闭
        /// </summary>
        public byte passivity_input2;
    }

    /// <summary>
    /// 设备信息
    /// </summary>
    public struct DEVICE_INFO
    {
        public byte ant1;                   //天线1
        public byte ant2;					//天线1
        public byte ant3;					//天线1
        public byte relay;					//继电器
        public byte device_varm;            //设备低温时(加热)
        public byte _2G_4G;				    //2G或4G模块
        public byte ethernet_port;			//以太网接口
        public byte USB;					//USB接口
        public byte RS232;					//串口RS232
        public byte RS485;					//串口RS485
        public byte Wiegand;				//韦根
        public byte Wifi;					//Wifi
        public byte Bluetooth;				//蓝牙
        public byte GPS;					//GPS
        public byte NB;					    //NB
        public byte _433M;					//433M
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string firmware_version;  //软件版本号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string hardware_version;  //硬件版本号
    }

    public struct HeartbeatStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string device_version;
        public byte read_card_status;
        public byte state_trigger;
        public byte read_head_state;         //心跳状态       
    }

    public struct DataFormatStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string ant_id;                       //天线号

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string RSSI;                         //信号强度

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string pc_value;                     //pc值

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string tag_area;				        //标签区域(0.RFU,1.EPC,2.TID,3.User)

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string alarm_status;                 //报警状态

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string private_data;                 //私有数据

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] time_stamp;                   //时间戳

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string user_data;                    //用户数据(自定数据)

        public byte user_data_length;               //用户数据长度

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string temper;                       //模块温度数据

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string direction;                    //通道门方向0 Or 1
    }

    public struct StandardDataStruct
    {
        public byte tag_type;                       //标签类型 默认为0x08
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public byte[] id_data;                      //id编号
        public byte data_len;                       //id数据长度
        public DataFormatStruct data_format;
        public byte special_tag_data;               //标签类型0x0D时数据内容
        public OutputTagData tag_data;              //标签数据  
    }

    public struct TagAreaData
    {
        public byte address;    //标签区域的起始地址                
        public byte length;     //标签区域的长度      
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public byte[] data;     //标签数据
    }

    public struct OutputTagData
    {
        public byte tag_type;               //0、常规标签 1、加密标签 2、悦和LTU31温度标签 3、悦和LTU32温度标签
        public byte tag_area;               //0、RFU 1、EPC 2、TID 3、User 4、EPC + TID 5、EPC + User
        public byte content;                //包含内容(bit7、温度 bit6、保留 bit5、保留 bit4、保留 bit3、保留 bit2、保留 bit1、保留 bit0、保留)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public TagAreaData[] area_data;     //标签区域数据(0.RFU,1.EPC,2.TID,3.User)对应数据的下标值
        public byte temper;                 //是否有温度数据(0.无  1.有)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string tempper_value;        //标签温度值
    }

    public struct OutputInfoStruct
    {
        public byte connect_type;           //串口 (0) | TCP Client(1) | TCP Server(2)监听
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string host;                 //通信方式(例如：COM1 or 192.168.1.200)
        public byte host_len;               //通信方式名称的长度
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string baud_rate_or_port;    //波特率(串口)或端口(IP)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string device_id;            //设备号
        public byte connect_exception;      //网络异常
        public byte heartbeat;              //心跳数据
        public HeartbeatStruct heartbeat_data;
        public byte std_data;			   //标准数据(为true)
        public StandardDataStruct standard_data;
    }

    public struct SocketInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] IP;               //通信方式(例如：COM1 or 192.168.1.200)
        public byte data_len;           //通信方式名称的长度
        public ushort port;             //端口
        public int socket;              //套字节
        //public sockaddr_in srvaddr;
    }

    public struct WorkFrequencyStruct
    {
        public byte standard;             //频率标准
        public double startFrequency;     //起始频点
        public ushort channelSpacing;     //信道间隔
        public byte chanelNumber;         //信道个数
    }

    public struct ChannelConfigStruct
    {
        public byte antennId;           //天线编号
        public byte enable;             //是否启用
        public byte power;              //功率
        public ushort workTime;         //工作时间
        public ushort freeTime;         //间隔时间（读卡时停顿时间，减少芯片发热）
    }

    public struct AntennaChannelStruct
    {
        public byte channelCount;           //通道数(1.通道 2.通道  4通道 8通道 16通道 32通道)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.Struct)]
        public ChannelConfigStruct[] config;
    }

    public struct QueryConfigStruct
    {
        public byte select;
        public byte session;
        public byte target;
        public byte Q_value;
        public byte target_flag;
    }

    public struct SelectConfigStruct
    {
        public byte target;
        public byte truncate;
        public byte action;
        public byte mem_bank;
        public byte point;
        public byte length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string mask;
    }

    public struct DataOutputFormatStruct
    {
        public byte antenna;//天线号
        public byte RSSI;   //信号强度
        public byte alarm;  //报警数据
        public byte pc_value; //PC值
        public byte tag_area;   //标签区域
        public byte private_data; //私有数据
        public byte tag_id_time; //读标签时间
        public byte user_data;   //用户自定义数据
    }

    public struct NetworkConfigStruct
    {
        public byte connect_mode;  //连接模式0.TCP Server 1.TCP Client
        public byte IP_mode;        //0.静态 1.动态
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] device_IP;    //设备IP号
        public byte device_IP_len;  //设备IP号长度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] subnet_mask;  //子网掩码
        public byte subnet_mask_len;//子网掩码长度
        public ushort device_port;  //设备端口
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] gate_way;     //网关
        public byte gate_way_len;   //网关长度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] dest_IP;      //目的IP
        public byte dest_IP_len;    //目的IP长度
        public ushort dest_port;    //目的端口
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] mac_address;  //MAC地址
        public byte mac_address_len; //MAC地址长度
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] dns;           //DNS
        public byte dns_len;         //DNS长度
    }

    /// <summary>
    /// 共用或单独相邻判别
    /// </summary>
    public struct AloneOrUnifyStruct 
    {
        public byte mode;   // 大于零共用或单独(0.同用 1.单独)
        public byte time;   // 共用的相邻判别
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public ushort[] antennaId;//天线(1 ~ 4)
    }

    /// <summary>
    /// 数据信息回调
    /// </summary>
    /// <param name="hDev"></param>
    /// <param name="outputInfo"></param>
    public delegate void FUN_DATA_CB(UIntPtr hDev, ref OutputInfoStruct outputInfo);

    /// <summary>
    /// 监听后Socket回调信息
    /// </summary>
    /// <param name="outputInfo"></param>
    public delegate void FUN_SOCKET_CB(ref SocketInfoStruct outputInfo);

    public class TM200
    {
        public int a() { return 0; }
        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="hServerSocket"></param>
        /// <param name="f"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "StartListening", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StartListening(ref UIntPtr hServerSocket, FUN_SOCKET_CB f, short port);

        /// <summary>
        /// 停止监听
        /// </summary>
        /// <param name="hServerSocket"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "StopListening", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopListening(UIntPtr hServerSocket);

        /// <summary>
        /// TCP Server 连接(监听后在回调中调用)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="socket"></param>
        /// <param name="f"></param>
        /// <param name="host"></param>
        /// <param name="baudrateOrPort"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "TCPServerConnect", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TCPServerConnect(ref UIntPtr hDev, int socket, FUN_DATA_CB f, string host, int baudrateOrPort);

        /// <summary>
        /// 断开设备连接
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "DisconnectDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DisconnectDev(UIntPtr hDev);

        /// <summary>
        /// 设备连接
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="f"></param>
        /// <param name="host"></param>
        /// <param name="baudrateOrPort"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "ConnectDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ConnectDev(ref UIntPtr hDev, FUN_DATA_CB f, string host, int baudrateOrPort);

        /// <summary>
        /// 查询固件版本号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryVersion", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryVersion(UIntPtr hDev, byte[] version);

        /// <summary>
        /// 单次读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data"></param>
        /// <param name="data_len"></param>
        /// <param name="device_no"></param>
        /// <param name="antenna_no"></param>
        /// <param name="IP_or_comm"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "SingleTagInv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SingleTagInv(UIntPtr hDev);

        /// <summary>
        /// 连续读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "BeginInv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BeginInv(UIntPtr hDev);


        /// <summary>
        /// 停止连续读卡
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "StopInv", CallingConvention = CallingConvention.Cdecl)]
        public static extern int StopInv(UIntPtr hDev);

        /// <summary>
        /// 查询网络参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryNetworkConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryNetworkConfig(UIntPtr hDev, ref NetworkConfigStruct config);

        /// <summary>
        /// 更新网络参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateNetworkConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateNetworkConfig(UIntPtr hDev, NetworkConfigStruct config);

        /// <summary>
        /// 更新频点
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="national_standard"></param>
        /// <param name="fixed_or_hopping_freq"></param>
        /// <param name="frequency_point"></param>
        /// <param name="frequency_point_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWorkFrequency", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWorkFrequency(UIntPtr hDev, WorkFrequencyStruct frequency);

        /// <summary>
        /// 查询频点
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="national_standard"></param>
        /// <param name="fixed_or_hopping_freq"></param>
        /// <param name="frequency_point"></param>
        /// <param name="frequency_point_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWorkFrequency", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWorkFrequency(UIntPtr hDev, ref WorkFrequencyStruct frequency);

        #region 工作模式
        /// <summary>
        /// 更新工作模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWorkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWorkMode(UIntPtr hDev, byte mode);

        /// <summary>
        /// 查询工作模式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWorkMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWorkMode(UIntPtr hDev, out byte mode);

        /// <summary>
        /// 更新相邻判别时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateAdjacentDiscriminantTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAdjacentDiscriminantTime(UIntPtr hDev, byte time);

        /// <summary>
        /// 查询相邻判别时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryAdjacentDiscriminantTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAdjacentDiscriminantTime(UIntPtr hDev, ref byte time);

        /// <summary>
        /// 更新触发延迟时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTriggerDelayTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTriggerDelayTime(UIntPtr hDev, byte time);

        /// <summary>
        /// 查询触发延迟时间
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTriggerDelayTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTriggerDelayTime(UIntPtr hDev, ref byte time);

        #endregion 工作模式

        #region 通讯方式
        /**********************通讯方式 Start ***********************/
        /// <summary>
        /// 查询通讯方式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryCommunicationType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryCommunicationType(UIntPtr hDev, ref byte type);

        /// <summary>
        /// 更新通讯方式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateCommunicationType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateCommunicationType(UIntPtr hDev, byte type);

        /// <summary>
        /// 更新串口波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"></param>
        /// <param name="baud_value"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateSerialPortBaudrate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateSerialPortBaudrate(UIntPtr hDev, byte type, byte baud_value);

        /// <summary>
        /// 查询串口波特率
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"></param>
        /// <param name="baud_value"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QuerySerialPortBaudrate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QuerySerialPortBaudrate(UIntPtr hDev, byte type, ref byte baud_value);

        /// <summary>
        /// 查询韦根脉冲宽度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWeigenPulseWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWeigenPulseWidth(UIntPtr hDev, ref byte width);

        /// <summary>
        /// 更新韦根脉冲宽度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWeigenPulseWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWeigenPulseWidth(UIntPtr hDev, byte width);

        /// <summary>
        /// 查询韦根脉冲周期
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="cycle"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWeigenPulseCycle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWeigenPulseCycle(UIntPtr hDev, ref byte cycle);

        /// <summary>
        /// 更新韦根脉冲周期
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="cycle"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWeigenPulseCycle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWeigenPulseCycle(UIntPtr hDev, byte cycle);

        /// <summary>
        /// 查询韦根协议
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="protocol"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWeigenProtocol", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWeigenProtocol(UIntPtr hDev, ref byte protocol);

        /// <summary>
        /// 更新韦根协议
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="protocol"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWeigenProtocol", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWeigenProtocol(UIntPtr hDev, byte protocol);
        /**********************通讯方式 End ***********************/
        #endregion 通讯方式


        /**********************WiFi参数配置 Start ***********************/
        /// <summary>
        /// 查询wifi配置
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="SSID"></param>
        /// <param name="SSID_len"></param>
        /// <param name="password"></param>
        /// <param name="password_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWifiConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWifiConfig(UIntPtr hDev, byte[] SSID, ref byte SSID_len, byte[] password, ref byte password_len);

        /// <summary>
        /// 更新wifi配置
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="SSID"></param>
        /// <param name="SSID_len"></param>
        /// <param name="password"></param>
        /// <param name="password_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWifiConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWifiConfig(UIntPtr hDev, byte[] SSID, byte SSID_len, byte[] password, byte password_len);

        /// <summary>
        /// 查询wifi TCP客户端
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_IP"></param>
        /// <param name="dest_IP_len"></param>
        /// <param name="dest_port"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWifiTCPClient", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWifiTCPClient(UIntPtr hDev, byte[] dest_IP, ref byte dest_IP_len, ref ushort dest_port);

        /// <summary>
        /// 更新wifi TCP客户端
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="dest_IP"></param>
        /// <param name="dest_IP_len"></param>
        /// <param name="dest_port"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWifiTCPClient", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWifiTCPClient(UIntPtr hDev, byte[] dest_IP, byte dest_IP_len, ushort dest_port);

        /// <summary>
        /// 查询wifi搜索(不建议使用(UDP搜索))
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryWifiSearch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryWifiSearch(UIntPtr hDev, ref bool status);

        /// <summary>
        /// 更新wifi搜索(不建议使用(UDP搜索))
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateWifiSearch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateWifiSearch(UIntPtr hDev, bool status);
        /**********************WiFi参数配置 End *************************/

        /**********************GPS参数配置 Start ***********************/
        /// <summary>
        /// 查询GPS信息输出
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="channel"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryGPSInfoOutput", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryGPSInfoOutput(UIntPtr hDev, ref byte channel, ref byte time);

        /// <summary>
        /// 更新GPS信息输出
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="channel"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateGPSInfoOutput", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateGPSInfoOutput(UIntPtr hDev, byte channel, byte time);
        /**********************GPS参数配置 End ***********************/

        /**********************HTTP参数配置 Start ***********************/
        /// <summary>
        /// 查询HTTP参数配置
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="url"></param>
        /// <param name="url_len"></param>
        /// <param name="port"></param>
        /// <param name="port_len"></param>
        /// <param name="common_type"></param>
        /// <param name="send_cycle"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryHttpParamConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryHttpParamConfig(UIntPtr hDev, byte[] url, ref byte url_len, byte[] port, ref byte port_len, ref byte common_type, ref byte send_cycle);

        /// <summary>
        /// 更新HTTP参数配置
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="url"></param>
        /// <param name="url_len"></param>
        /// <param name="port"></param>
        /// <param name="common_type"></param>
        /// <param name="send_cycle"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateHttpParamConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateHttpParamConfig(UIntPtr hDev, byte[] url, byte url_len, ushort port, byte common_type, byte send_cycle);
        /**********************HTTP参数配置 End ***********************/

        /**********************TCP参数配置 Start ***********************/
        /// <summary>
        /// 查询TCP目的(IP或域名)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP_or_domain_name"></param>
        /// <param name="data_len"></param>
        /// <param name="port"></param>
        /// <param name="port_len"></param>
        /// <param name="network"></param>
        /// <param name="wifi"></param>
        /// <param name="_4G"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTCPDestination", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTCPDestination(UIntPtr hDev, byte[] IP_or_domain_name, ref byte data_len, byte[] port, ref byte port_len, ref byte network, ref byte wifi, ref byte _4G);

        /// <summary>
        /// 更新TCP目的(IP或域名)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="IP_or_domain_name"></param>
        /// <param name="data_len"></param>
        /// <param name="port"></param>
        /// <param name="network"></param>
        /// <param name="wifi"></param>
        /// <param name="_4G"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTCPDestination", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTCPDestination(UIntPtr hDev, byte[] IP_or_domain_name, byte data_len, ushort port, byte network, byte wifi, byte _4G);
        /**********************TCP参数配置 End ***********************/
        /****************************2020-12-30 八、通讯参数配置 End ***********************************************/

        /****************************2020-12-30 九、其它操作 Start ***********************************************/
        /**********************蜂鸣器配置 Start ***********************/
        /// <summary>
        /// 查询蜂鸣器状态(声音)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryBuzzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryBuzzer(UIntPtr hDev, ref byte status);

        /// <summary>
        /// 更新蜂鸣器状态(声音)
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateBuzzer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateBuzzer(UIntPtr hDev, byte status);

        /// <summary>
        /// 查询报警音类型
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="alarm_tone"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryAlarmTone", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAlarmTone(UIntPtr hDev, ref byte alarm_tone);

        /// <summary>
        /// 更新报警音类型
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="alarm_tone"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateAlarmTone", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAlarmTone(UIntPtr hDev, byte alarm_tone);
        /**********************蜂鸣器配置 End ************************/

        /**********************LED配置 Start ************************/
        /// <summary>
        /// 查询LED灯状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryLEDLamp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryLEDLamp(UIntPtr hDev, ref byte status);

        /// <summary>
        /// 更新LED灯状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateLEDLamp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateLEDLamp(UIntPtr hDev, byte status);
        /**********************LED配置 End **************************/

        /**********************继电器配置(GPIO) Start ****************/
        /// <summary>
        /// 查询GPIO
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="gpio"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryGPIO", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryGPIO(UIntPtr hDev, ref DevGPIO gpio);

        /// <summary>
        /// 更新GPIO
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="gpio"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateGPIO", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateGPIO(UIntPtr hDev, DevGPIO gpio);
        /**********************继电器配置(GPIO) End ******************/
        #region 其他操作

        /**********************标签信息输出配置 Start *****************/
        /// <summary>
        /// 查询数据输出格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <param name="RSSI"></param>
        /// <param name="alarm"></param>
        /// <param name="private_data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDataOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDataOutputFormat(UIntPtr hDev, ref DataOutputFormatStruct dataFormat);

        /// <summary>
        /// 更新数据输出格式
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <param name="RSSI"></param>
        /// <param name="alarm"></param>
        /// <param name="private_data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateDataOutputFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDataOutputFormat(UIntPtr hDev, DataOutputFormatStruct dataFormat);
        /**********************标签信息输出配置 End *******************/

        /**********************恢复出厂设置 Start *******************/
        /// <summary>
        /// 出厂设置
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "FactoryReset", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FactoryReset(UIntPtr hDev);
        /**********************恢复出厂设置 End *********************/


        /**********************软件复位 Start **********************/
        /// <summary>
        /// 设备软件复位
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "ResetDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ResetDev(UIntPtr hDev);
        /**********************软件复位 End ************************/

        /**********************设备配置信息 Start *******************/
        /// <summary>
        /// 查询设备配置信息
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDeviceConfigInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDeviceConfigInfo(UIntPtr hDev, ref DEVICE_INFO info);

        /// <summary>
        /// 查询设备MAC地址
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="network"></param>
        /// <param name="wifi"></param>
        /// <param name="_4G"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDeviceInfoMac", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDeviceInfoMac(UIntPtr hDev, byte[] network, byte[] wifi, byte[] _4G);
        /**********************设备配置信息 End *********************/

        /**********************查询设备是否读标签状态 Start **********************/
        /// <summary>
        /// 查询设备读标签状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryReadTagStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryReadTagStatus(UIntPtr hDev, ref byte status);
        /**********************查询设备是否读标签状态 End ***********************/

        /// <summary>
        /// 查询天线通道数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryChannelCount", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryChannelCount(UIntPtr hDev, ref byte count);

        /// <summary>
        /// 更新天线参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateAntennaConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAntennaConfig(UIntPtr hDev, AntennaChannelStruct antenna);

        /// <summary>
        /// 查询天线参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antenna"></param>
        /// <param name="antenna_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryAntennaConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAntennaConfig(UIntPtr hDev, ref AntennaChannelStruct antenna);

        /// <summary>
        /// 更新设备号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateDeviceId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDeviceId(UIntPtr hDev, ushort device_id);

        /// <summary>
        /// 查询设备号
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDeviceId", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDeviceId(UIntPtr hDev, ref ushort device_id);

        #endregion 其他操作

        /// <summary>
        /// 查询用户自定义数据
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data_length"></param>
        /// <param name="data">数组长度>=16</param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryUserCustomData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryUserCustomData(UIntPtr hDev, ref byte data_length, byte[] data);

        /// <summary>
        /// 更新用户自定义数据
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="data_length"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateUserCustomData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateUserCustomData(UIntPtr hDev, byte data_length, byte[] data);

        /// <summary>
        /// 查询设备号非EPROM
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDeviceIdNotEPROM", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDeviceIdNotEPROM(UIntPtr hDev, ref ushort device_id);

        /// <summary>
        /// 更新设备号非EPROM
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="device_id"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateDeviceIdNotEPROM", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDeviceIdNotEPROM(UIntPtr hDev, ushort device_id);

        /// <summary>
        /// 检测天线是否已接
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="channelCount"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "CheckAntennaState", CallingConvention = CallingConvention.Cdecl)]
        public static extern int CheckAntennaState(UIntPtr hDev, ref byte channelCount, byte[] enable);

        /************************ TM200 Start *************************************/
        /// <summary>
        /// 查询当前工作温度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="temp_value"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryCurrentWorkTemperature", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryCurrentWorkTemperature(UIntPtr hDev, ref byte temp_value);

        /// <summary>
        /// 更新温度保护开关状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="temp_switch_state"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTemperatureProtectionSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTemperatureProtectionSwitch(UIntPtr hDev, byte temp_switch_state);

        /// <summary>
        /// 查询温度保护开关状态
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="temp_switch_state"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTemperatureProtectionSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTemperatureProtectionSwitch(UIntPtr hDev, ref byte temp_switch_state);

        /// <summary>
        /// 更新链路参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateLinkParameters", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateLinkParameters(UIntPtr hDev, byte mode);

        /// <summary>
        /// 查询链路参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryLinkParameters", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryLinkParameters(UIntPtr hDev, ref byte mode);

        /// <summary>
        /// 更新解调阈值
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateDemodulationThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateDemodulationThreshold(UIntPtr hDev, uint value);

        /// <summary>
        /// 查询解调阈值
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryDemodulationThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryDemodulationThreshold(UIntPtr hDev, ref uint value);

        /// <summary>
        /// 回波测试
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="antennaId"></param>
        /// <param name="loss_power"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "ReturnLossTest", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReturnLossTest(UIntPtr hDev, byte antennaId, ref ushort loss_power);

        /// <summary>
        /// 更新Query参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateQueryParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateQueryParams(UIntPtr hDev, QueryConfigStruct config);

        /// <summary>
        /// 查询Query参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryQueryParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryQueryParams(UIntPtr hDev, ref QueryConfigStruct config);

        /// <summary>
        /// 更新Select参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateSelectParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateSelectParams(UIntPtr hDev, SelectConfigStruct config);

        /// <summary>
        /// 查询Select参数
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QuerySelectParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QuerySelectParams(UIntPtr hDev, ref SelectConfigStruct config);

        /************************ TM200 End *************************************/

        /// <summary>
        /// 指定区域读标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <param name="data_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "ReadTagData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadTagData(UIntPtr hDev, byte bank, byte begin, byte length, byte[] data, ref byte data_len);



        /// <summary>
        /// 指定区域读标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <param name="data_len"></param>
        /// <param name="mode"></param>
        /// <param name="match_length"></param>
        /// <param name="match_data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "ReadTagDataMatchParameter", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadTagDataMatchParameter(UIntPtr hDev, byte bank, byte begin, byte length, byte[] data, ref byte data_len, byte mode, byte match_length, byte[] match_data);


        /// <summary>
        /// 指定区域写标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "WriteTagData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteTagData(UIntPtr hDev, byte bank, byte begin, byte length, byte[] data);


        /// <summary>
        /// 指定区域写标签  2024-03-11新增
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <param name="data"></param>
        /// <param name="mode"></param>
        /// <param name="match_length"></param>
        /// <param name="match_data"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "WriteTagDataMatchParameter", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteTagDataMatchParameter(UIntPtr hDev, byte bank, byte begin, byte length, byte[] data, byte mode, byte match_length, byte[] match_data);

        /// <summary>
        /// 标签加锁
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="lock_bank"></param>
        /// <param name="lock_type"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "LockOrUnlockTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockOrUnlockTag(UIntPtr hDev, byte lock_bank, byte lock_type, byte[] password);


        /// <summary>
        ///  指定标签数据加锁    2024-03-11新增
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="lock_bank"></param>
        /// <param name="lock_type"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "LockOrUnlockTagMatchParameter", CallingConvention = CallingConvention.Cdecl)]
        public static extern int LockOrUnlockTagMatchParameter(UIntPtr hDev, byte lock_bank, byte lock_type, byte[] password, byte mode, byte match_length, byte[] match_data);

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "KillTag", CallingConvention = CallingConvention.Cdecl)]
        public static extern int KillTag(UIntPtr hDev, byte[] password);


        /// <summary>
        ///  指定标签销毁  2024-03-11新增         
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "KillTagMatchParameter", CallingConvention = CallingConvention.Cdecl)]
        public static extern int KillTagMatchParameter(UIntPtr hDev, byte[] password, byte mode, byte match_length, byte[] match_data);

        /// <summary>
        /// 设置读卡区域
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank">
        ///         0.Reserved 
        ///         1.EPC
        ///         2.TID
        ///         3.User
        ///         4.EPC + TID
        ///         5.EPC + User
        /// </param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTagReadCardArea", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTagReadCardArea(UIntPtr hDev, byte bank); //2022-06-23 add

        /// <summary>
        /// 查询读卡区域
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank">
        ///         0.Reserved 
        ///         1.EPC
        ///         2.TID
        ///         3.User
        ///         4.EPC + TID
        ///         5.EPC + User
        /// </param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTagReadCardArea", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTagReadCardArea(UIntPtr hDev, ref byte bank); //2022-06-23 add

        /// <summary>
        /// 设置标签类型
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"> 
        ///         0.常规标签
        ///         1.加密标签
        ///         2.悦和LTU31测温标签
        ///         3.悦和LTU32测温标签
        /// </param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTagType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTagType(UIntPtr hDev, byte type); //2022-06-23 add

        /// <summary>
        /// 查询标签类型
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="type"> 
        ///         0.常规标签
        ///         1.加密标签
        ///         2.悦和LTU31测温标签
        ///         3.悦和LTU32测温标签
        /// </param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTagType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTagType(UIntPtr hDev, ref byte type); //2022-06-23 add

        /// <summary>
        /// 标签授权2022-07-27 add
        /// </summary>
        /// <param name="hDev"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "TagAuthorize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TagAuthorize(UIntPtr hDev);

        /// <summary>
        /// 查询授权密码2022-07-27 add
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="pwd"></param>
        /// <param name="pwd_len"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryAuthorizePwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAuthorizePwd(UIntPtr hDev,byte [] pwd,ref byte pwd_len);

        /// <summary>
        /// 修改授权密码2022-07-27 add
        /// </summary>
        /// <param name="hDev">句柄</param>
        /// <param name="oldPwd">原授权密码2个字节</param>
        /// <param name="newPwd">新授权密码2个字节</param>
        /// <param name="pwd_len">固定数组长度都为2</param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateAuthorizePwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAuthorizePwd(UIntPtr hDev, byte[] oldPwd, byte[] newPwd, byte pwd_len);

        /// <summary>
        /// 更新相邻判别时间2022-08-11
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="aloneOrUnify"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateAdjacentDiscriminantTimeAloneOrUnify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateAdjacentDiscriminantTimeAloneOrUnify(UIntPtr hDev, AloneOrUnifyStruct aloneOrUnify);

        /// <summary>
        /// 查询相邻判别时间2022-08-11
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="aloneOrUnify"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryAdjacentDiscriminantTimeAloneOrUnify", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryAdjacentDiscriminantTimeAloneOrUnify(UIntPtr hDev, ref AloneOrUnifyStruct aloneOrUnify);
        
        /************************** 此功能暂时不建议对外公开 2022-06-24 Start ***************************************/

        /// <summary>
        /// 设置标签区域指定地址和长度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="enable"></param>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "UpdateTagAreaSpecifiedAddressAndLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UpdateTagAreaSpecifiedAddressAndLength(UIntPtr hDev, byte bank, byte enable, byte address, byte length); //2022-06-23 add


        /// <summary>
        /// 查询标签区域指定地址和长度
        /// </summary>
        /// <param name="hDev"></param>
        /// <param name="bank"></param>
        /// <param name="enable"></param>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("libTM200.dll", EntryPoint = "QueryTagAreaSpecifiedAddressAndLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QueryTagAreaSpecifiedAddressAndLength(UIntPtr hDev, byte bank, ref byte enable, ref byte address, ref byte length); //2022-06-23 add

        /************************** 此功能暂时不建议对外公开 2022-06-24 End ***************************************/
    }
}
