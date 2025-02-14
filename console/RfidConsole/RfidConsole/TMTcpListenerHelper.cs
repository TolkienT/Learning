using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RfidConsole
{
    public class TMTcpListenerHelper
    {
        public static async Task AddListener(int port)
        {
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

                    // 启动一个新任务来处理客户端请求  
                    _ = Task.Run(async () => await HandleClientComm(client));
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // 停止监听  
                listener?.Stop();
                Console.WriteLine("已停止监听");
                await AddListener(port);
            }
        }

        // 处理客户端通信的方法  
        private static async Task HandleClientComm(object client)
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
                    try
                    {
                        Memory<byte> span = message.AsMemory(0, bytesRead);
                        byte[] result = span.ToArray();
                        var res = await HandleMessage(result);
                        if (res is not null && res.Length > 0)
                        {
                            clientStream.Write(res, 0, res.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"JT808数据处理错误: {ex}");
                    }
                }
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("tcp客户端报错:" + ex.ToString());
            }

        }

        private static async Task<byte[]> HandleMessage(byte[] bytes)
        {
            string hex = ByteArrayHelper.ByteArrayToHex(bytes);
            Console.WriteLine("收到数据:" + hex);

            return null;
        }

    }
}
