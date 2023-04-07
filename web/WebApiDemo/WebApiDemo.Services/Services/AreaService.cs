using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Repository.IRepositories;
using WebApiDemo.Repository.Repositories;
using WebApiDemo.Services.IServices;

namespace WebApiDemo.Services.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            this._areaRepository = areaRepository;
        }

        public string Test()
        {
            return _areaRepository.Test();
        }
    }
}
