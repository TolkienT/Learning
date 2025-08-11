using System;
using System.IO.Ports;

namespace TestNET5Condole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 配置参数
            var portName = "COM3";
            var baudRate = 19200;
            var dataBits = 8;
            var stopBits = StopBits.One;
            var parity = Parity.None;
            var slaveId = 1;

            var reader = new ModbusRtuReader(portName, baudRate, dataBits, stopBits, parity, (byte)slaveId);

            try
            {
                // 读取保持寄存器
                ushort startAddress = 0;  // Modbus地址40001对应寄存器地址0
                ushort numberOfRegisters = 5;

                var registers = reader.ReadHoldingRegisters(startAddress, numberOfRegisters);

                if (registers.Length > 0)
                {
                    Console.WriteLine($"成功读取 {registers.Length} 个寄存器:");
                    for (int i = 0; i < registers.Length; i++)
                    {
                        Console.WriteLine($"寄存器 {startAddress + i} (4x{startAddress + i + 40001}): {registers[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("未收到响应数据");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }



            Console.ReadKey();
        }
    }
}
