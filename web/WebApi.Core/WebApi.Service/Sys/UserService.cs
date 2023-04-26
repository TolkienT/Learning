using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IService.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Service.Base;

namespace WebApi.Service.Sys
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        public UserService(IBaseRepository<UserEntity> baseRepository) : base(baseRepository)
        {

        }


    }
}
