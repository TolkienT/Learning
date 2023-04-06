using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpListenerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listener Start!");
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9000);
            listener.Start();
            bool flag = true;
            while (flag)
            {
                if (listener.Pending())
                {
                    var client = listener.AcceptTcpClient();
                    Console.WriteLine("client connected");

                    Task.Run(() =>
                    {
                        var stream = client.GetStream();
                        var remote = client.Client.RemoteEndPoint;

                        while (true)
                        {
                            if (stream.DataAvailable)
                            {
                                byte[] data = new byte[1024];
                                int length = stream.Read(data, 0, 1024);
                                string str = Encoding.UTF8.GetString(data, 0, length);
                                Console.WriteLine($"From:{remote}:Received ({str})");

                                var sendData = Encoding.UTF8.GetBytes("res:" + str);
                                stream.Write(sendData, 0, sendData.Length);
                            }
                            if (!client.Connected)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                    });

                    flag = false;
                }

                Thread.Sleep(1000);
            }


            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
