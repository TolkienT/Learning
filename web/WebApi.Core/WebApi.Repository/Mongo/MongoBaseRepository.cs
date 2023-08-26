using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.App;
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
            string className = Appsettings.GetApp(new string[] { "Mongo", "ClassName", typeof(TEntity).Name });
            if (!string.IsNullOrWhiteSpace(className))
            {
                var col = _context.Db.GetCollection<TEntity>(className);
                await col.InsertOneAsync(entity);
            }

        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> lambda)
        {
            string className = Appsettings.GetApp(new string[] { "Mongo", "ClassName", typeof(TEntity).Name });
            if (!string.IsNullOrWhiteSpace(className))
            {
                return await _context.Db.GetCollection<TEntity>(className)
                .Find(lambda)
                .FirstOrDefaultAsync();
            }
            return null;

        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> lambda)
        {
            return await _context.Db.GetCollection<TEntity>("login_log")
                 .Find(lambda)
                 .ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Db.GetCollection<TEntity>("login_log")
                .Find(x => 1 == 1)
                .ToListAsync();
        }


    }
}
