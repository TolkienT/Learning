using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using TM200Demo;
using System.Threading;

namespace RfidConsole
{
    public class TMHelper
    {
        static UIntPtr hServerSocket = UIntPtr.Zero;

        public static FUN_SOCKET_CB socket_callback = new FUN_SOCKET_CB(SocketCallBack);

        public static FUN_DATA_CB data_callback = new FUN_DATA_CB(DataCallBack);

        //存放已连接的对象
        public static Dictionary<string, UIntPtr> hashMap = new Dictionary<string, UIntPtr>();

        private static string getDeviceKey(string host, UIntPtr hDev)
        {
            //ushort device_id = 0;
            ////int result = TM200.QueryDeviceIdNotEPROM(hDev, ref device_id);
            //int result = TM200.QueryDeviceId(hDev, ref device_id);
            //string device = "null";
            //if(result > 0){
            //    device = device_id.ToString().PadLeft(5, '0');
            //}
            //return host + "_(" + hDev + ")_" + device;
            return host + "_(" + hDev + ")";
        }

        public static void Listen(short port)
        {
            int result = TM200.StartListening(ref hServerSocket, socket_callback, port);
            if (result > 0)
            {
                Console.WriteLine("启动监听成功");
            }
            else
            {
                Console.WriteLine("启动监听失败");
            }


        }
        public static void SocketCallBack(ref SocketInfoStruct socketInfo)
        {
            try
            {
                string host = Encoding.Default.GetString(socketInfo.IP);//IP地址
                int baudrateOrPort = socketInfo.port; //端口号
                host = host.Replace("\0", "");
                //Console.WriteLine("IP: " + host + " PORT: " + baudrateOrPort);
                UIntPtr hDev = UIntPtr.Zero;
                int result = TM200.TCPServerConnect(ref hDev, socketInfo.socket, data_callback, host, baudrateOrPort);//添加连接的对象;
                if (result > 0)
                {
                    Console.WriteLine("连接成功");
                    //string keys = host + "_(" + hDev + ")";// "_已连接";
                    string keys = getDeviceKey(host, hDev);
                    hashMap.Add(keys, hDev);

                    StartRead();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("回调失败:" + ex.ToString());
            }
        }

        public static void DataCallBack(UIntPtr hDevs, ref OutputInfoStruct outputInfo)
        {
            Console.WriteLine("device 001 DataCallBack IP: " + outputInfo.host + " PORT: " + outputInfo.baud_rate_or_port);
        }

        public static void StartRead()
        {
            ThreadStart childref = new ThreadStart(beginInv);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        private static void beginInv()
        {
            try
            {
                //string key = selecteDevice();
                //if (null == key)
                //{
                //    return;
                //}
                //currentStatus = true;
                //btnClearListView.Enabled = false;
               
                int result = TM200.BeginInv(hashMap.Values.ToList()[0]);
                if (result > 0)
                {
                    Console.WriteLine("连续读卡成功");
                    return;
                }
                else
                {
                    Console.WriteLine("连续读卡失败");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("连续读卡失败:" + ex.ToString());
            }
        }
    }
}
