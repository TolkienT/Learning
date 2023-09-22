// See https://aka.ms/new-console-template for more information
using Google.Protobuf;
using Test;

Console.WriteLine("Hello, World!");



TestContact con = new()
{
    Name = "Test",
    Address="长沙",
    ID=1
};


//序列化操作
byte[] data = new byte[con.CalculateSize()];
using (CodedOutputStream cos = new CodedOutputStream(data))
{
    con.WriteTo(cos);
    //data = cos.to.ToArray();
}

//反序列化操作
TestContact t1 = TestContact.Parser.ParseFrom(data);
Console.WriteLine($"反序列化得到：{t1}");

var datas = con.ToByteArray();
//反序列化操作
TestContact t2 = TestContact.Parser.ParseFrom(datas);
Console.WriteLine($"反序列化2得到：{t2}");

Console.ReadKey();