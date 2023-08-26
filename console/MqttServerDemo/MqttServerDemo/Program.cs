// See https://aka.ms/new-console-template for more information
using MqttServerDemo;

Console.WriteLine("Hello, World!");



MqttHostService mqttHostService = new();
mqttHostService.StartAsync();


Console.ReadKey();
