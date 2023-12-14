using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.IService.Auth;
using WebServer.Model.Dtos.Auth;
using WebServer.Model.Models;

namespace WebServer.Core.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
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
        [Route("Query")]
        [AllowAnonymous]

        public async Task<HttpResultModel> Query([FromQuery] UserQueryDto input)
        {
            var users = await _userService.Query();
            var res = _mapper.Map<List<UserDto>>(users);
            return new HttpResultModel(res);
        }


    }
}
