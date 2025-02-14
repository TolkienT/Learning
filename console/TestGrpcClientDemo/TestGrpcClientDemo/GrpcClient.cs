using Grpc.Core.Logging;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mapservice.AreaInfo;

namespace TestGrpcClientDemo
{
    public class GrpcClient
    {
        private static Channel channel;
        private static AreaFenceInfo.AreaFenceInfoClient client;

        public static async Task StartService()
        {
            string target = "127.0.0.1:50062";

            try
            {
                var options = new List<ChannelOption>();
                options.Add(new ChannelOption(ChannelOptions.MaxSendMessageLength, 100 * 1024 * 1024));
                options.Add(new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 100 * 1024 * 1024));
                channel = new Channel(target, ChannelCredentials.Insecure, options);
                client = new AreaFenceInfo.AreaFenceInfoClient(channel);

                GetAreaBoundaryPointsReq request = new();
                request.AreaIds.Add("1");
                var response = await client.GetAreaBoundaryPointsAsync(request);

                Console.WriteLine("xxx");
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误信息:" + ex);
            }
        }
    }
}
