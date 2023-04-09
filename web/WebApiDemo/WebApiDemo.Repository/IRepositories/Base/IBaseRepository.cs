using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Repository.IRepositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);

    }
}
