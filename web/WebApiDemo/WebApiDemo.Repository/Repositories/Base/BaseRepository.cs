using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Model.Db;
using WebApiDemo.Repository.IRepositories.Base;

namespace WebApiDemo.Repository.Repositories.Base
{
    public class BaseRepository<TEnity> : MyDbContext<TEnity>, IBaseRepository<TEnity> where TEnity : class, new()
    {
        public BaseRepository()
        {

        }

        public async Task<bool> Add(TEnity entity)
        {
            var i=await Db.Insertable<TEnity>(entity).ExecuteCommandAsync();
            return i > 0;
        }
    }
}
