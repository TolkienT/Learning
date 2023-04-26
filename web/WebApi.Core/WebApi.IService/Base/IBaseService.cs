using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IService.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity model);

        Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> lambda);

        Task<bool> Delete(TEntity model);
    }
}
