using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.IService.Redis
{
    public interface IRedisService
    {
        Task<bool> StringSet(string key, string value);

        Task<string> StringGet(string key);


    }
}
