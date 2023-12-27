using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebServer.IRepository.Auth;
using WebServer.IRepository.Base;
using WebServer.IService.Auth;
using WebServer.Model.Dtos.Auth;
using WebServer.Model.Entities.Auth;
using WebServer.Service.Base;

namespace WebServer.Service.Auth
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

        public async Task<UserEntity> GetUser(Expression<Func<UserEntity, bool>> lambda)
        {
            return await _baseDal.First(lambda);
        }

        public async Task<bool> Register(UserRegisterDto dto)
        {
            var user = _mapper.Map<UserEntity>(dto);

            return await _userRepo.Register(user);

        }

        //public async Task<bool> UpdateUser(UpdateUserDto dto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
