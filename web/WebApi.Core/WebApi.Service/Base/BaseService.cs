using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IService.Base;

namespace WebApi.Service.Base
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

        public async Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> lambda)
        {
            return await _baseDal.Query(lambda);
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await _baseDal.Delete(model);
        }
    }
}
