using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Model.Db;
using WebApiDemo.Model.Models;
using WebApiDemo.Repository.IRepositories.Base;

namespace WebApiDemo.Repository.Repositories.Base
{
    public class BaseRepository<TEntity> :MyDbContext<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        //private readonly SqlSugarScope _dbBase;
        //public BaseRepository(ISqlSugarClient sqlSugarClient)
        //{
        //    _dbBase = sqlSugarClient as SqlSugarScope;
        //}

        //public ISqlSugarClient Db
        //{
        //    get { return _dbBase; }
        //}

        public async Task<bool> Add(TEntity entity)
        {
            var i = await _db.Insertable<TEntity>(entity).ExecuteCommandAsync();
            return i > 0;
        }
    }
}
