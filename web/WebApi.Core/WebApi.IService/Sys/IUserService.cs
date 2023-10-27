using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IService.Base;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities.Sys;

namespace WebApi.IService.Sys
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<bool> Register(UserRegisterDto dto);
        Task<bool> UpdateUser(UpdateUserDto dto);
        Task<UserEntity> GetUser(Expression<Func<UserEntity, bool>> lambda);
    }
}
