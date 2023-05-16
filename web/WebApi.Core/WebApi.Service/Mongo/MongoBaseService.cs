using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IRepository.Mongo;
using WebApi.IService.Base;
using WebApi.IService.Mongo;

namespace WebApi.Service.Mongo
{
    public class MongoBaseService<TEntity> : IMongoBaseService<TEntity> where TEntity : class, new()
    {
        public IMongoBaseRepository<TEntity> _baseDal { get; set; }//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public MongoBaseService(IMongoBaseRepository<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }
        public Task<bool> Add(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TEntity model)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> lambda)
        {
            return await _baseDal.GetAsync(lambda);
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> lambda)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryAll()
        {
            throw new NotImplementedException();
        }
    }
}
