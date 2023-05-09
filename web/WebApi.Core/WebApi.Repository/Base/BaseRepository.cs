using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.Model.Db;

namespace WebApi.Repository.Base
{
    public class BaseRepository<TEntity> : MyDbContext<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {

        public async Task<bool> Add(TEntity entity)
        {
            var i = await _db.Insertable(entity).ExecuteCommandAsync();
            return i > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            var i = await _db.Deleteable(entity).ExecuteCommandAsync();
            return i > 0;

        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> lambda)
        {
            return await _db.Queryable<TEntity>().WhereIF(lambda is not null, lambda).ToListAsync();
        }

        public async Task<List<TEntity>> Query()
        {
            return await _db.Queryable<TEntity>().ToListAsync();
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> lambda)
        {
            if (lambda is not null)
                return await _db.Queryable<TEntity>().FirstAsync(lambda);
            return null;
        }
    }
}