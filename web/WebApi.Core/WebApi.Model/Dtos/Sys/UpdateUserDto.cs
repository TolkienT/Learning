using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Enums;

namespace WebApi.Model.Dtos.Sys
{
    public class UpdateUserDto
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
    }
}
