using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Helpers;
using WebApi.IRepository;
using WebApi.IRepository.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Repository.Base;

namespace WebApi.Repository.Sys
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public async Task<bool> Register(UserEntity user, UserSecurityEntity security)
        {
            await _db.BeginTranAsync();
            try
            {
                await _db.Insertable(user).ExecuteCommandAsync();

                await _db.Insertable(security).ExecuteCommandAsync();

                await _db.CommitTranAsync();

                Log4NetHelper.Debug("注册成功");
                return true;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("注册失败", ex);
                await _db.RollbackTranAsync();
                return false;
            }
        }

    }
}
