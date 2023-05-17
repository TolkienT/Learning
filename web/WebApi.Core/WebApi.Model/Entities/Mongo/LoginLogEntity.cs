using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities.Mongo
{
    public class LoginLogEntity : MongoBaseEntity
    {

        [BsonElement("user_name")]
        public string UserName { get; set; }
        [BsonElement("status")]
        public int Status { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
    }
}
