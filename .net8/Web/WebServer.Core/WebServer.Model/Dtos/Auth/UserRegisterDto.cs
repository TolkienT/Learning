using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Enums;

namespace WebServer.Model.Dtos.Auth
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        //public string NickName { get; set; }
        public Gender Gender { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
