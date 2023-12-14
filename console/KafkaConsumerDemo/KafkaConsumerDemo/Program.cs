// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using KafkaConsumerDemo;

_ = Task.Run(async () =>
{
    await ConsumeMethodDemo.InitCosume();
});

//_ = Task.Run(async () =>
//{
//    await TestConsume.InitCosume();
//});

Console.ReadKey();
