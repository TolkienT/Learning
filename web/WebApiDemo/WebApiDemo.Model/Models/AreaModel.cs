using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Model.Models
{
    [SugarTable("area")]
    public class AreaModel
    {
        [SugarColumn(IsPrimaryKey =true,IsIdentity =true,ColumnName ="id")]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "area_name")]
        public string AreaName { get; set; }
        [SugarColumn(ColumnName = "area_code")]
        public string AreaCode { get; set; }

    }
}
