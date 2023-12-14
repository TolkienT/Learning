using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Entities.Mongo
{
    public class LoginLogEntity : MongoBaseEntity
    {
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("user_name")]
        public string UserName { get; set; }
        [BsonElement("status")]
        public int Status { get; set; }
        [BsonElement("message")]
        public string Message { get; set; }
    }
}
