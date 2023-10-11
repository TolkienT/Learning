using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducerDemo
{
    public class ProducerMethodDemo
    {
        public static async Task SendMsg()
        {
            var topicName = "test";
            var config = new ProducerConfig
            {
                BootstrapServers = "127.0.0.1:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "consumer-user-test",
                SaslPassword = "consumer-pwd-test"
                //SslCaLocation = @"D:\Net_Program\Net_Kafka\04_SSL\ca-cert" //SSL证书
            };
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //异步生产消息
                        var dr = await p.ProduceAsync(topicName, new Message<Null, string> { Value = $"测试数据:{i}" });
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
