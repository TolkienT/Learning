using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities.Sys
{
    [SugarTable("sys_user_security")]
    public class UserSecurityEntity : BaseEntity
    {
        [SugarColumn(ColumnName = "user_id")]
        public long UserId { get; set; }
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }
        [SugarColumn(ColumnName = "last_visit_time")]
        public DateTime? LastVisitTime { get; set; }
    }
}
