using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.IRepository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);
        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> lambda);
        Task<bool> Delete(TEntity model);
        Task<TEntity> First(Expression<Func<TEntity, bool>> lambda);
    }
}
