using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Common.Helpers
{
    public class IdHelper
    {
        private static IdWorker worker;

        public IdHelper()
        {
            worker = new IdWorker(1, 1);
        }

        public static long GetSnowflakeId()
        {
            if (worker is null)
            {
                worker = new IdWorker(1, 1);
            }
            return worker.NextId();
        }
    }
}
