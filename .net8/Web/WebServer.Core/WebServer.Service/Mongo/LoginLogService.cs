using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;
using WebServer.IRepository.Mongo;
using WebServer.IService.Mongo;
using WebServer.Model.Entities.Mongo;

namespace WebServer.Service.Mongo
{
    public class LoginLogService
    {
        private readonly IMongoCollection<LoginLogEntity> _loginLogCollection;

        public LoginLogService()
        {
            string className = AppSettingHelper.GetApp(new string[] { "Mongo", "ClassName", typeof(LoginLogEntity).Name });
            string connectionStr = AppSettingHelper.GetApp(new string[] { "Mongo", "ConnectionString" });
            string dataBaseName = AppSettingHelper.GetApp(new string[] { "Mongo", "DatabaseName" });
            var mongoClient = new MongoClient(connectionStr);
            var mongoDatabase = mongoClient.GetDatabase(dataBaseName);

            _loginLogCollection = mongoDatabase.GetCollection<LoginLogEntity>(className);
        }

        public async Task<LoginLogEntity> GetAsync(Expression<Func<LoginLogEntity, bool>> lambda)
        {
            return await _loginLogCollection.Find(lambda).FirstOrDefaultAsync();
        }

        public async Task<List<LoginLogEntity>> GetListAsync(Expression<Func<LoginLogEntity, bool>> lambda)
        {
            return await _loginLogCollection.Find(lambda).ToListAsync();
        }

        public async Task Add(LoginLogEntity entity)
        {
            await _loginLogCollection.InsertOneAsync(entity);
        }

        public async Task Delete(object id)
        {
            await _loginLogCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
