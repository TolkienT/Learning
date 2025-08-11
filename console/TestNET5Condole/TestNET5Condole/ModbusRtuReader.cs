using NModbus;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNET5Condole
{
    public class ModbusRtuReader
    {
        private readonly string _portName;
        private readonly int _baudRate;
        private readonly int _dataBits;
        private readonly StopBits _stopBits;
        private readonly Parity _parity;
        private readonly byte _slaveId;

        public ModbusRtuReader(string portName, int baudRate, int dataBits,
                             StopBits stopBits, Parity parity, byte slaveId)
        {
            _portName = portName;
            _baudRate = baudRate;
            _dataBits = dataBits;
            _stopBits = stopBits;
            _parity = parity;
            _slaveId = slaveId;
        }

        public ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfPoints)
        {
            using (var serialPort = new SerialPort(_portName, _baudRate, _parity, _dataBits, _stopBits))
            {
                try
                {
                    serialPort.Open();

                    // 3.0.70 版本创建主站的方式
                    var adapter = new SerialPortAdapter(serialPort);
                    var factory = new ModbusFactory();
                    var modbusMaster = factory.CreateRtuMaster(adapter);

                    // 设置超时（毫秒）
                    modbusMaster.Transport.ReadTimeout = 1000;
                    modbusMaster.Transport.WriteTimeout = 1000;

                    // 读取保持寄存器
                    return modbusMaster.ReadHoldingRegisters(_slaveId, startAddress, numberOfPoints);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"读取错误: {ex.Message}");
                    return Array.Empty<ushort>();
                }
                finally
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                }
            }
        }
    }
}
