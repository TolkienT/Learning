using MQTTnet;
using MQTTnet.Server;
using System;
using System.Threading.Tasks;

namespace MqttServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始构建Mqtt服务!");
            var option = new MqttServerOptionsBuilder()
                .WithDefaultEndpointPort(1883)
                .WithConnectionBacklog(100)
                .Build();

            var mqttServer = new MqttFactory().CreateMqttServer(option);
            mqttServer.ValidatingConnectionAsync+= ValidateConnect;
            mqttServer.StartAsync();


            Console.ReadKey();
        }

        static async Task ValidateConnect(ValidatingConnectionEventArgs connectArgs)
        {


        } 
    }
}
