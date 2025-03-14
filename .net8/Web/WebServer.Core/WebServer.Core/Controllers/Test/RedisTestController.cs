using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebServer.IService.Redis;
using WebServer.Model.Models;
using WebServer.Filter;

namespace WebServer.Core.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedisTestController : ControllerBase
    {
        private readonly IRedisService _redis;

        public RedisTestController(
            IRedisService redis
            )
        {
            _redis = redis;
        }

        [HttpGet]
        [Route("StringGet")]
        [LoggingActionFilter(Order = 10)]
        public async Task<HttpResultModel> TestGetString(string key)
        {
            var value = await _redis.StringGet(key);
            return new HttpResultModel()
            {
                Status = Model.Enums.HttpResultStatus.OK,
                Success = true,
                Data = value
            };
        }

        [HttpGet]
        [Route("StringSet")]
        public async Task<HttpResultModel> TestSetString(string key, string value)
        {
            var res = await _redis.StringSet(key, value);
            return new HttpResultModel()
            {
                Status = Model.Enums.HttpResultStatus.OK,
                Success = true,
                Data = res
            };
        }

    }
}
