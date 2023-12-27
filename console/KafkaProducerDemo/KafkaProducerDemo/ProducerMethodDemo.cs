using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducerDemo
{
    public class ProducerMethodDemo
    {
        public static async Task SendMsg()
        {
            var topicName = "yutong-trxk-mine-vehicle";
            //var topicName = "trxk-mine-yutong-task-create";
            //var topicName = "trxk-mine-yutong-task-finish";

            var config = new ProducerConfig
            {
                //BootstrapServers = "124.220.210.116:9092",
                BootstrapServers = "124.70.193.28:9094",
                //SecurityProtocol = SecurityProtocol.SaslSsl,
                //SaslMechanism = SaslMechanism.Plain,
                //SaslUsername = "consumer-user-test",
                //SaslPassword = "consumer-pwd-test"
                //SslCaLocation = @"D:\Net_Program\Net_Kafka\04_SSL\ca-cert" //SSL证书
            };
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var model = new TruckRealTimeInfo()
                        {
                            batterySOC = 80.23f,
                            deviceId = "36",
                            direction = 0,
                            lat = "0",
                            lon = "0",
                            altitude = "0",
                            online = 0,
                            trueSpeed = 0,
                            vehicleLn = "豫A00110",
                            vehicleState = 3,
                            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                        };

                        string str = JsonConvert.SerializeObject(model);

                        //string str = "{\"excavatorNum\":482,\"sideName\":\"草庙345采面\",\"sideNo\":\"10415\",\"taskName\":\"20231222草庙345-221205采面爆堆482\",\"taskNo\":\"47616\",\"taskType\":2,\"taskVolume\":33.00,\"time\":\"2023-12-22 15:30:52\",\"unloadDicId\":10021,\"unloadDicName\":\"骨料线\",\"vehicleNos\":[\"豫A00088\"]}";

                        //string str = "[{\"endTime\":\"2023-12-22 15:36:23\",\"taskId\":47616,\"vehicleNo\":\"豫A00088\"}]";

                        //异步生产消息
                        var dr = await p.ProduceAsync(topicName, new Message<Null, string> { Value = str });
                        Console.WriteLine($"发送数据:{str}");
                        //Console.WriteLine($"发送数据qwe123:{i}");
                        //var res= await p.ProduceAsync("qwe123", new Message<Null, string> { Value = $"qwe{i}" });
                        Thread.Sleep(1000);

                    }

                }
                catch (ProduceException<Null, string> pe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(pe.Error.Reason);
                }
            }

        }

    }
}
