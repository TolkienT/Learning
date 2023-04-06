using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MqttClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始构建Mqtt客户端!");
            var mqttFactory = new MqttFactory();
            //using (var mqttClient = mqttFactory.CreateMqttClient())
            //{
            //    var option = new MqttClientOptionsBuilder()
            //        .WithWebSocketServer("localhost:8083/mqtt")
            //        //.WithTcpServer("localhost",8083)
            //        .WithTimeout(TimeSpan.FromSeconds(5))
            //        .WithProtocolVersion(MqttProtocolVersion.V500)
            //        .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
            //        .Build();
            //    option.ClientId = "TestClientId";
            //    option.Credentials = new MqttClientCredentials("admin", Encoding.ASCII.GetBytes("TestPwd"));
            //    //接收信息
            //    mqttClient.ApplicationMessageReceivedAsync += MqttClientReceived;


            //    var response = mqttClient.ConnectAsync(option).Result;
            //    Console.WriteLine("The Mqtt is Connected");

            //    string topic = "testtopic/1";
            //    var subOption = new MqttClientSubscribeOptions()
            //    {
            //        TopicFilters = new List<MqttTopicFilter>()
            //        {
            //            new MqttTopicFilter()
            //            {
            //                Topic = topic,
            //                QualityOfServiceLevel=MqttQualityOfServiceLevel.AtMostOnce
            //            }
            //        }
            //    };
            //    mqttClient.SubscribeAsync(subOption);


            //    //Thread.Sleep(30000);
            //    ////断开连接
            //    //var mqttClientDisconnectOptions = mqttFactory.CreateClientDisconnectOptionsBuilder().Build();
            //    //mqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
            //    //Console.WriteLine("End");
            //}

            var mqttClient = mqttFactory.CreateMqttClient();
            var option = new MqttClientOptionsBuilder()
                                .WithWebSocketServer("localhost:8083/mqtt")
                                //.WithTcpServer("localhost",8083)
                                .WithTimeout(TimeSpan.FromSeconds(5))
                                .WithProtocolVersion(MqttProtocolVersion.V500)
                                .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
                                .Build();
            option.ClientId = "TestClientId";
            option.Credentials = new MqttClientCredentials("admin", Encoding.ASCII.GetBytes("TestPwd"));
            //接收信息
            mqttClient.ApplicationMessageReceivedAsync += MqttClientReceived;


            var response = mqttClient.ConnectAsync(option).Result;
            Console.WriteLine("The Mqtt is Connected");

            string topic = "testtopic/1";
            //subscribe
            //var subOption = new MqttClientSubscribeOptions()
            //{
            //    TopicFilters = new List<MqttTopicFilter>()
            //        {
            //            new MqttTopicFilter()
            //            {
            //                Topic = topic,
            //                QualityOfServiceLevel=MqttQualityOfServiceLevel.AtMostOnce
            //            }
            //        }
            //};
            //mqttClient.SubscribeAsync(subOption);

            //publish
            string publishMessage = "test publish";
            var appMsg = new MqttApplicationMessage()
            {
                Topic = topic,
                Payload = Encoding.UTF8.GetBytes(publishMessage),
                QualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce
            };
            mqttClient.PublishAsync(appMsg);

            Console.ReadKey();
        }

        static async Task MqttClientReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            Console.WriteLine("接收信息:" + Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        }
    }
}
