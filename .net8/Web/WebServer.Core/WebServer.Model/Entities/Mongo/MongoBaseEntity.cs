using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Entities.Mongo
{
    public class MongoBaseEntity
    {
        public MongoBaseEntity()
        {
            Id = ObjectId.GenerateNewId();
        }
        [BsonId]
        [BsonElement("_id")]
        public object Id
        {
            get; set;
        }
    }
}
