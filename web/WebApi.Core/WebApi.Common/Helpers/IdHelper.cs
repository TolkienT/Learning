using Snowflake.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Helpers
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
            return worker.NextId();
        }
    }
}
