using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Repository.IRepositories.Base;
using WebApiDemo.Services.IServices.Base;

namespace WebApiDemo.Services.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private readonly IBaseRepository<TEntity> _dal;

        public BaseService(IBaseRepository<TEntity> dal)
        {
            _dal = dal;
        }

        public async Task<bool> Add(TEntity model)
        {
            return await _dal.Add(model);
        }
    }
}
