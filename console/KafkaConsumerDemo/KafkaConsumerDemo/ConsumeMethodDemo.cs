using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KafkaConsumerDemo
{
    public class ConsumeMethodDemo
    {
        public static async Task InitCosume()
        {
            var conf = new ConsumerConfig
            {
                //BootstrapServers = "124.220.210.116:9092",
                BootstrapServers = "124.70.193.28:9094",
                GroupId = "test-consumer-group",
                ClientId = "consumer-test",
                //SecurityProtocol = SecurityProtocol.SaslPlaintext,
                //SaslMechanism = SaslMechanism.Plain,
                //SaslUsername = "consumer-user-test",
                //SaslPassword = "consumer-pwd-test"
            };

            await Consume(conf);
        }


        static async Task Consume(ConsumerConfig conf)
        {
            using (var c = new ConsumerBuilder<string, string>(conf)
            .SetKeyDeserializer(Deserializers.Utf8)
            .SetValueDeserializer(Deserializers.Utf8)
            .SetErrorHandler((_, e) =>
            {
                Console.WriteLine("连接出错：" + e.Reason);
            })
             .SetStatisticsHandler((_, json) =>
             {
                 Console.WriteLine($" - {DateTime.Now:yyyy-MM-dd HH:mm:ss} > 消息监听中..");
             })
            .SetPartitionsAssignedHandler((c, partitions) =>
            {
                string partitionsStr = string.Join(", ", partitions);
                Console.WriteLine($" - 分配的 kafka 分区: {partitionsStr}");
            })
            .Build())
            {
                c.Subscribe("yutong-trxk-mine-vehicle");
                //c.Subscribe("trxk-mine-yutong-task-create");
                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(500);

                            if (cr != null)
                            {
                                Console.WriteLine("收到数据:" + cr.Message.Value);

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("获取数据失败1：" + ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取数据失败2：" + ex.ToString());

                    c.Close();
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine("重新连接");
                await Consume(conf);
            }
        }


    }
}
