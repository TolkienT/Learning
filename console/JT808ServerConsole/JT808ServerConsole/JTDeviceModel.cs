using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class JTDeviceModel
    {
        public int Id { get; set; }

        public string TerminalNo { get; set; }

        public string DeviceName { get; set; }
    }

    public class VehicleEquipmentAttachDataModel
    {
        public string FileName { get; set; }
        public uint Offset { get; set; }

        public string HexStr { get; set; }
    }
}
