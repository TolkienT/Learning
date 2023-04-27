using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.Base;
using WebApi.IRepository.Sys;
using WebApi.IService.Sys;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Service.Base;

namespace WebApi.Service.Sys
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        private static IMapper _mapper;
        private readonly IUserRepository _userRepo;
        public UserService(
             IMapper mapper,
             IUserRepository userRepo,
             IBaseRepository<UserEntity> baseRepository
            )
            : base(baseRepository)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<bool> Register(UserRegisterDto dto)
        {
            var user = _mapper.Map<UserEntity>(dto);

            var security = new UserSecurityEntity()
            {
                UserId = user.Id,
                Password = dto.Password
            };

            return await _userRepo.Register(user, security);

        }

        public async Task<bool> UpdateUser(UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
