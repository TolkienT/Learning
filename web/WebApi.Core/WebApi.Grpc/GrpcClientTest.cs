using Grpc.Core;
using Grpc.Net.Client;
using GrpcDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Grpc.Services;

namespace WebApi.Grpc
{
    public class GrpcClientTest
    {
        private static Order.OrderClient client;
        private static GrpcChannel channel;
        
        public static void StartGrpcClient()
        {
            string url = "http://localhost:5048";
            try
            {
                channel = GrpcChannel.ForAddress(url);
                client = new Order.OrderClient(channel);

                QueryOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void QueryOrder()
        {
            try
            {
                var client = new Order.OrderClient(channel);
                var reply = client.QueryOrder(new QueryOrderRequest()
                {
                    Id = 1
                });

                Console.WriteLine($"{reply}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



    }
}
