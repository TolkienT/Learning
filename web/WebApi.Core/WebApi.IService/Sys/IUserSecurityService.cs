using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IService.Base;
using WebApi.Model.Entities.Sys;

namespace WebApi.IService.Sys
{
    public interface IUserSecurityService : IBaseService<UserSecurityEntity>
    {
        Task<UserSecurityEntity> GetSecurity(Expression<Func<UserSecurityEntity, bool>> lambda);
    }
}
