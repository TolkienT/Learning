using Grpc.Core;
using GrpcDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Grpc.Services;

namespace WebApi.Grpc
{
    public class GrpcServerTest
    {
        private static Server server;


        public static void StartGrpcService()
        {
            string host = "127.0.0.1";
            int port = 5048;
            try
            {
                var options = new List<ChannelOption>
                {
                    new ChannelOption(ChannelOptions.MaxSendMessageLength, 100 * 1024 * 1024),
                    new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 100 * 1024 * 1024)
                };

                server = new Server(options)
                {
                    Services = { Order.BindService(new OrderService()) },
                    Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
                };
                server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

    }
}
