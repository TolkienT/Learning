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
        public IBaseRepository<TEntity> _baseDal { get; set; }//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public BaseService(IBaseRepository<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }

        public async Task<bool> Add(TEntity model)
        {
            return await _baseDal.Add(model);
        }
    }
}
