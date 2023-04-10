using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Model.Models;
using WebApiDemo.Repository.IRepositories;
using WebApiDemo.Repository.IRepositories.Base;
using WebApiDemo.Repository.Repositories;
using WebApiDemo.Services.IServices;
using WebApiDemo.Services.Services.Base;

namespace WebApiDemo.Services.Services
{
    public class AreaService : BaseService<AreaModel>, IAreaService
    {
        public AreaService(IBaseRepository<AreaModel> baseRepository) : base(baseRepository)
        {

        }

    }
}
