using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Enums;

namespace WebApi.Model.Dtos.Sys
{
    public class UserRegisterDto
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public Gender Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
