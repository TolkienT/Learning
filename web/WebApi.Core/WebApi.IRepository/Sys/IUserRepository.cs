using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.Model.Entities.Sys;

namespace WebApi.IRepository.Sys
{
    public interface IUserRepository
    {
        Task<bool> Register(UserEntity user, UserSecurityEntity security);
    }
}
