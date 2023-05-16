using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Entities.Mongo
{
    public class LoginLogEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public object Id { get; set; }
        [BsonElement("user_name")]
        public string UserName { get; set; }
        [BsonElement("isSuccess")]
        public bool IsSuccess { get; set; }
    }
}
