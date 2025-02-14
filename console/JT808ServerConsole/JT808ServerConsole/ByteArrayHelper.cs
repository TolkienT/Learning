using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class ByteArrayHelper
    {
        public static string ByteArrayToHex(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2")); // 使用"x2"格式将字节转换为两位的16进制数  
            }
            return sb.ToString();
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Convert.FromHexString(hex);
        }

        public static string FillZero(string str, int length)
        {
            while (str.Length < length)
            {
                str = "0" + str;
            }
            return str;
        }
    }
}
