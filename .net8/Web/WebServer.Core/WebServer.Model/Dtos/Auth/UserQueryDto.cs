using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Dtos.Auth
{
    public class UserQueryDto
    {
        public long? Id { get; set; }
        public string UserName { get; set; }
    }
}
