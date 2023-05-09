using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IRepository.Sys;
using WebApi.IService.Sys;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities.Sys;
using WebApi.Service.Base;

namespace WebApi.Service.Sys
{
    public class UserSecurityService : BaseService<UserSecurityEntity>, IUserSecurityService
    {
        private static IMapper _mapper;
        private readonly IUserRepository _repo;
        public UserSecurityService(
             IMapper mapper,
             IUserRepository repo,
             IBaseRepository<UserSecurityEntity> baseRepository
            )
            : base(baseRepository)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserSecurityEntity> GetSecurity(Expression<Func<UserSecurityEntity, bool>> lambda)
        {
            var entity =await _baseDal.First(lambda);
            return entity;
        }
    }
}
