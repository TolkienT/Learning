﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Dtos.Sys
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VerifyCode { get; set; }

    }
}
