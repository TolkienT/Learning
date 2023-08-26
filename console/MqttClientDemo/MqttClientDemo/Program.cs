// See https://aka.ms/new-console-template for more information
using MqttClientDemo;

Console.WriteLine("Hello, World!");


MqttClientService mqttClientService = new();
mqttClientService.MqttClientStart();
Thread.Sleep(1000);
mqttClientService.Publish("test");


Console.ReadKey();