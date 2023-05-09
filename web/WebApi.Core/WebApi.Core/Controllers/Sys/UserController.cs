using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.IService.Base;
using WebApi.IService.Sys;
using WebApi.IService.User;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Model.Enums;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers.Sys
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserSecurityService _userSecurityService;

        public UserController(
            IMapper mapper,
            IUserService userService,
            IUserSecurityService userSecurityService
            )
        {
            _mapper = mapper;
            _userService = userService;
            _userSecurityService = userSecurityService;
        }

        [HttpGet]
        [Route("Query")]
        public async Task<HttpResultModel<List<UserDto>>> Query([FromQuery] UserQueryInput input)
        {
            var users = await _userService.Query();
            var res = _mapper.Map<List<UserDto>>(users);
            return new HttpResultModel<List<UserDto>>("Success", res);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<HttpResultModel<string>> Register([FromBody] UserRegisterDto dto)
        {
            var flag = await _userService.Register(dto);
            if (flag)
                return new HttpResultModel<string>("Success", null);
            return new HttpResultModel<string>("注册失败", null, HttpResultStatus.Error);
        }

        [HttpPost]
        [Route("{userId}/Update")]
        public async Task<HttpResultModel<string>> UpdateUser(string userId, [FromBody] UpdateUserDto dto)
        {
            var flag = await _userService.UpdateUser(dto);
            if (flag)
                return new HttpResultModel<string>("Success", null);
            return new HttpResultModel<string>("注册失败", null, HttpResultStatus.Error);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<HttpResultModel<string>> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.GetUser(x => x.UserName == dto.UserName);
            if(user is null)
                return new HttpResultModel<string>("用户不存在", null, HttpResultStatus.Error);
            var security = await _userSecurityService.GetSecurity(x => x.UserId == user.Id);
            if (security is not null)
            {
                if (security.Password != dto.Password)
                {
                    return new HttpResultModel<string>("密码错误", null,HttpResultStatus.Error);
                }
            }

            return new HttpResultModel<string>("Success", null);
        }
    }
}
