using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebServer.IRepository.Mongo;
using WebServer.IService.Mongo;

namespace WebServer.Service.Mongo
{
    public class MongoBaseService<TEntity> : IMongoBaseService<TEntity> where TEntity : class, new()
    {
        public IMongoBaseRepository<TEntity> _baseDal { get; set; }//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public MongoBaseService(IMongoBaseRepository<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }
        public async Task Add(TEntity model)
        {
            await _baseDal.AddAsync(model);
        }

        public Task<bool> Delete(TEntity model)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> lambda)
        {
            return await _baseDal.First(lambda);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> lambda)
        {
            return await _baseDal.GetListAsync(lambda);
        }

        public async Task<List<TEntity>> QueryAll()
        {
            return await _baseDal.GetAllAsync();
        }
    }
}
