using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IService.Mongo
{
    public interface IMongoBaseService<TEntity> where TEntity : class
    {
        Task Add(TEntity model);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> lambda);

        Task<List<TEntity>> QueryAll();

        Task<TEntity> First(Expression<Func<TEntity, bool>> lambda);

        Task<bool> Delete(TEntity model);

    }
}
