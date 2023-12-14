using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Entities.Auth
{
    [SugarTable("role")]
    public class RoleEntity : BaseEntity
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
