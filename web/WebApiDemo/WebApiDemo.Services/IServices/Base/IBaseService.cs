using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Services.IServices.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity model);
    }
}
