// See https://aka.ms/new-console-template for more information
using TestGrpcClientDemo;

Console.WriteLine("Hello, World!");

await GrpcClient.StartService();

Console.WriteLine("End");
