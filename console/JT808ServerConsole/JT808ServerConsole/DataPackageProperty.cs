using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    /// <summary>
    /// 补传数据包信息
    /// </summary>
    public class DataPackageProperty
    {
        /// <summary>
        /// 数据偏移量
        /// </summary>
        public uint Offset { get; set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public uint Length { get; set; }
    }
}
