using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common.Helpers;
using WebServer.IService.Redis;

namespace WebServer.Service.Redis
{
    public class RedisServiceImpl : IRedisService
    {
        public ConnectionMultiplexer redis { get; set; }
        public IDatabase _db { get; set; }

        public RedisServiceImpl()
        {
            string myRedisConStr = AppSettingHelper.GetApp(new string[] { "Redis", "MyRedisConStr" });
            if (string.IsNullOrWhiteSpace(myRedisConStr))
            {
                myRedisConStr = "124.220.210.116:6379";
            }
            redis = ConnectionMultiplexer.Connect(myRedisConStr);
            _db = redis.GetDatabase();
        }

        public async Task<string> StringGet(string key)
        {
            return await _db.StringGetAsync(key);
        }

        public async Task<bool> StringSet(string key, string value)
        {
            return await _db.StringSetAsync(key, value);
        }
    }
}
