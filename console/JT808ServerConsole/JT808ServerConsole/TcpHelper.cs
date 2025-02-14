using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JT808.Protocol;

namespace JT808ServerConsole
{
    public class TcpHelper
    {
        public static void AddListener()
        {

            const int port = 11000;

            // 创建TCP监听器  
            TcpListener listener = new TcpListener(IPAddress.Any, port);

            try
            {
                // 开始监听  
                listener.Start();
                Console.WriteLine("服务器已启动，等待连接...");

                while (true)
                {
                    // 阻塞调用，等待客户端连接  
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("客户端已连接");

                    // 启动一个新线程来处理客户端请求，以便可以继续监听其他客户端  
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // 停止监听  
                listener.Stop();
                Console.WriteLine("已停止监听");
                AddListener();
            }
        }

        // 处理客户端通信的方法  
        private static void HandleClientComm(object client)
        {
            try
            {
                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();

                byte[] message = new byte[4096];
                int bytesRead;

                // 循环读取客户端发送的消息  
                while (true)
                {
                    bytesRead = 0;

                    try
                    {
                        // 阻塞调用，直到读取到数据或连接关闭  
                        bytesRead = clientStream.Read(message, 0, message.Length);
                    }
                    catch
                    {
                        // 客户端断开连接  
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        // 客户端已断开连接  
                        break;
                    }

                    // 将字节转换为字符串并输出  
                    string hexString = ByteArrayHelper.ByteArrayToHex(message);
                    Console.WriteLine($"收到来自客户端的消息: {hexString}");

                    JT808Helper.JT808Serializer.Deserialize(message);


                    // 响应客户端（可选）  
                    string serverResponse = "服务器已收到消息";
                    byte[] msg = Encoding.ASCII.GetBytes(serverResponse);
                    clientStream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"已发送响应给客户端: {serverResponse}");
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("tcp客户端报错:" + ex.ToString());
            }

        }




    }
}
