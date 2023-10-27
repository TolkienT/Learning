using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities.Auth
{
    [SugarTable("sys_role")]
    public class RoleEntity : BaseInfo
    {
        [SugarColumn(ColumnName = "id", IsNullable = false, IsPrimaryKey = true)]
        public int Id { get; set; }
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }
        [SugarColumn(ColumnName = "description")]
        public string Description { get; set; }
        [SugarColumn(ColumnName = "order")]
        public int Order { get; set; }

    }
}
