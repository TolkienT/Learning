using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities
{
    public class BaseInfo
    {
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string DeleteUser { get; set; }
        public DateTime DeleteTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
