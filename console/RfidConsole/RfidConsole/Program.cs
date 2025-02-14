using System;

namespace RfidConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("任务开始!");

            //TMHelper.Listen(20058);


            TMTcpListenerHelper.AddListener(56662);

            Console.ReadKey();
        }
    }
}
