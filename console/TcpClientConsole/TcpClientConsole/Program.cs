using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("client start");
            var client = new TcpClient();
            client.Connect("127.0.0.1", 9000);
            var stream = client.GetStream();

            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        if(stream.DataAvailable)
                        {
                            byte[] data=new byte[1024];
                            int len = stream.Read(data, 0, 1024);
                            var message=Encoding.UTF8.GetString(data, 0, len);
                            Console.WriteLine(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                }
            });

            int length = 1024;
            byte[] buffer = new byte[length];
            buffer = Encoding.UTF8.GetBytes("张三");

            stream.Write(buffer, 0, buffer.Length);

            buffer = Encoding.UTF8.GetBytes("李四");
            stream.Write(buffer, 0, buffer.Length);

            stream.Close();
            client.Close();

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
