// See https://aka.ms/new-console-template for more information
using MqttClientDemo;
using System.Text;

Console.WriteLine("Hello, World!");

// 注册GBK编码提供者  
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//MqttClientService mqttClientService = new();
//mqttClientService.MqttClientStart();
//Thread.Sleep(1000);
//mqttClientService.Publish("test");

TestClient testClient = new();
testClient.MqttClientStart();

Console.ReadKey();