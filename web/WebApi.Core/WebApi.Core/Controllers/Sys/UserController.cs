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
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private static IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(
            IMapper mapper,
            IUserService userService
            )
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<HttpResultModel<List<UserDto>>> Query([FromQuery] UserQueryInput input)
        {
            var users = await _userService.Query(x => 1 == 1);
            var res = _mapper.Map<List<UserDto>>(users);
            return new HttpResultModel<List<UserDto>>("error", res);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<HttpResultModel<string>> Register([FromBody] UserRegisterDto dto)
        {
            var flag = await _userService.Register(dto);
            if (flag)
                return new HttpResultModel<string>("success", null);
            return new HttpResultModel<string>("注册失败", null, HttpResultStatus.Error);
        }
    }
}
