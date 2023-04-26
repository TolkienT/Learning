using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.IService.Base;
using WebApi.IService.User;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Entities.Sys;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers.Sys
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private static IMapper _mapper;
        private readonly IBaseService<UserEntity> _userService;
        //private readonly IAreaService _areaService;
        public UserController(
            IMapper mapper,
            IBaseService<UserEntity> userService
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
    }
}
