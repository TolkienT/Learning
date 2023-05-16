using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Mongo;
using WebApi.Model.Db;

namespace WebApi.Repository.Mongo
{
    public class MongoBaseRepository<TEntity> : IMongoBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly MongoDbContext _context;

        public MongoBaseRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> lambda)
        {

            return await _context.Db.GetCollection<TEntity>("LoginLog")
                .Find(lambda)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> lambda)
        {
            return await _context.Db.GetCollection<TEntity>("LoginLog")
                 .Find(lambda)
                 .ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


    }
}
