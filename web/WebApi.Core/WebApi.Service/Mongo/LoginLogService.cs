using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IRepository.Mongo;
using WebApi.IService.Mongo;
using WebApi.Model.Entities.Mongo;
using WebApi.Model.Entities.Sys;
using WebApi.Repository.Base;

namespace WebApi.Service.Mongo
{
    public class LoginLogService : MongoBaseService<LoginLogEntity>, ILoginLogService
    {
        private readonly IMongoBaseRepository<LoginLogEntity> _loginLogRepository;

        public LoginLogService(
            IMongoBaseRepository<LoginLogEntity> baseRepository
        )
            : base(baseRepository)
        {
            _loginLogRepository = baseRepository;
        }

        public async Task<LoginLogEntity> GetAsync(Expression<Func<LoginLogEntity, bool>> lambda)
        {
            return await _loginLogRepository.First(lambda);
        }

    }
}
