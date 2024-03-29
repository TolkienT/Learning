﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.IRepository.Mongo
{
    public interface IMongoBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> First(Expression<Func<TEntity, bool>> lambda);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> lambda);
        Task<List<TEntity>> GetAllAsync();

    }
}
