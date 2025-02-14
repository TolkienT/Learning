using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT808ServerConsole
{
    public class JT808DataHelper
    {
        public static DateTime GetDateTimeByBytes(byte[] bytes)
        {
            string timeStr = "20" + bytes[0].ToString("x2") + "-" + bytes[1].ToString("x2") + "-" + bytes[2].ToString("x2") + " " + bytes[3].ToString("x2") + ":" + bytes[4].ToString("x2") + ":" + bytes[5].ToString("x2");
            DateTime time = DateTime.Parse(timeStr);
            return time;
        }

    }
}
