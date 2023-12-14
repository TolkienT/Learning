using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.IRepository.Auth;
using WebServer.Model.Entities.Auth;
using WebServer.Repository.Base;

namespace WebServer.Repository.Auth
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        //public async Task<bool> Register(UserEntity user, UserSecurityEntity security)
        //{
        //    await _db.BeginTranAsync();
        //    try
        //    {
        //        await _db.Insertable(user).ExecuteCommandAsync();

        //        await _db.Insertable(security).ExecuteCommandAsync();

        //        await _db.CommitTranAsync();

        //        Log4NetHelper.Debug("注册成功");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4NetHelper.Error("注册失败", ex);
        //        await _db.RollbackTranAsync();
        //        return false;
        //    }
        //}

    }
}
