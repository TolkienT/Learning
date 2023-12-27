using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Entities.Mongo;

namespace WebServer.IService.Mongo
{
    public interface ILoginLogService : IMongoBaseService<LoginLogEntity>
    {

    }
}
