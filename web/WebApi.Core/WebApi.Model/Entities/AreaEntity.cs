using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities
{
    [SugarTable("area")]
    public class AreaEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "id")]
        public int Id { get; set; } = 1;
        [SugarColumn(ColumnName = "area_name")]
        public string AreaName { get; set; }
        [SugarColumn(ColumnName = "area_code")]
        public string AreaCode { get; set; }

    }
}
