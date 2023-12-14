using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;

namespace WebServer.Model.Db
{
    public class MongoDbContext 
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext()
        {
            var client = new MongoClient(AppSettingHelper.GetApp(new string[] { "Mongo", "ConnectionString" }));
            _database = client.GetDatabase(AppSettingHelper.GetApp(new string[] { "Mongo", "DatabaseName" }));
        }

        public IMongoDatabase Db
        {
            get { return _database; }
        }
    }
}
