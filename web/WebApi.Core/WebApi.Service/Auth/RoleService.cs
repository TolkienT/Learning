using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IRepository.Sys;
using WebApi.IService.Auth;
using WebApi.Model.Entities.Auth;
using WebApi.Service.Base;

namespace WebApi.Service.Auth
{
    public class RoleService : BaseService<RoleEntity>, IRoleService
    {
        private static IMapper _mapper;
        public RoleService(
             IMapper mapper,
             IBaseRepository<RoleEntity> baseRepository
            )
            : base(baseRepository)
        {
            _mapper = mapper;
        }


    }
}
