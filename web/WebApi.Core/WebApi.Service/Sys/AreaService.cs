using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IService.User;
using WebApi.Model.Entities;
using WebApi.Service.Base;

namespace WebApi.Service.User
{
    public class AreaService : BaseService<AreaEntity>, IAreaService
    {
        public AreaService(IBaseRepository<AreaEntity> baseRepository) : base(baseRepository)
        {

        }

    }
}
