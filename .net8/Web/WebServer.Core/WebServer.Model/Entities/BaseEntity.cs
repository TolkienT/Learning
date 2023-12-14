using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;

namespace WebServer.Model.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            if (Id <= 0)
            {
                Id = IdHelper.GetSnowflakeId();
            }
        }
        //IsIdentity = true,
        [SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
        public long Id { get; set; }
    }
}
