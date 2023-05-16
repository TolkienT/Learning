using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.App;

namespace WebApi.Model.Db
{
    public class MongoDbContext : IDatabaseContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext()
        {
            var client = new MongoClient(Appsettings.GetApp(new string[] { "Mongo", "ConnectionString" }));
            _database = client.GetDatabase(Appsettings.GetApp(new string[] { "Mongo", "DatabaseName" }));
        }

        public IMongoDatabase Db
        {
            get { return _database; }
        }


    }
}
