using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebServer.IService.Base;
using WebServer.Model.Dtos.Auth;
using WebServer.Model.Entities.Auth;

namespace WebServer.IService.Auth
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<bool> Register(UserRegisterDto dto);
        //Task<bool> UpdateUser(UpdateUserDto dto);
        Task<UserEntity> GetUser(Expression<Func<UserEntity, bool>> lambda);
    }
}
