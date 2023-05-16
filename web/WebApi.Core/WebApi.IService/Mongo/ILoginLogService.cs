using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Entities.Mongo;

namespace WebApi.IService.Mongo
{
    public interface ILoginLogService : IMongoBaseService<LoginLogEntity>
    {

    }
}
