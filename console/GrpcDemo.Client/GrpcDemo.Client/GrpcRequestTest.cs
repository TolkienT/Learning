using Grpc.Net.Client;
using GrpcDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcDemo.Client
{
    public class GrpcRequestTest
    {
        public static void CreateOrder()
        {
            //常规使用，https
            string url = "https://localhost:7059";
            using (var channel = GrpcChannel.ForAddress(url))
            {
                var client = new Order.OrderClient(channel);
                var reply = client.CreateOrder(new CreateOrderRequest()
                {
                    OrderNo = DateTime.Now.ToString("yyyMMddHHmmss"),
                    OrderName = "冰箱22款",
                    Price = 1688
                });

                Console.WriteLine($"结果:{reply.Result},message:{reply.Message}");
            }

        }

        public static void QueryOrder()
        {

            //使用http
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            string url = "http://localhost:5048";
            try
            {
                using (var channel = GrpcChannel.ForAddress(url))
                {
                    var client = new Order.OrderClient(channel);
                    var reply = client.QueryOrder(new QueryOrderRequest()
                    {
                        Id = 1
                    });

                    Console.WriteLine($"{reply}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


    }
}
