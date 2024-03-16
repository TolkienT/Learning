using AutoMapper;
using Dm.filter.log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTaste;
using System.IdentityModel.Tokens.Jwt;
using WebServer.Common.Helpers;
using WebServer.Filter;
using WebServer.IService.Auth;
using WebServer.IService.Mongo;
using WebServer.Model.Dtos.Auth;
using WebServer.Model.Enums;
using WebServer.Model.Models;
using WebServer.Service.Mongo;

namespace WebServer.Core.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private static IMapper _mapper;
        private readonly IUserService _userService;
        private readonly LoginLogService _loginLogService;

        public UserController(
            IMapper mapper,
            IUserService userService,
            LoginLogService loginLogService
            )
        {
            _mapper = mapper;
            _userService = userService;
            _loginLogService = loginLogService;
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

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<HttpResultModel> Register([FromBody] UserRegisterDto dto)
        {
            var flag = await _userService.Register(dto);
            if (flag)
                return new HttpResultModel();
            return new HttpResultModel()
            {
                Success = false,
                Message = "注册失败",
                Status = HttpResultStatus.Error
            };
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<HttpResultModel> Login([FromBody] LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return new HttpResultModel()
                {
                    Message = "用户名或密码不能为空",
                    Status = HttpResultStatus.Error,
                    Success = false
                };
            }
            var user = await _userService.GetUser(x => x.UserName == dto.UserName);
            if (user is null)
            {
                return new HttpResultModel()
                {
                    Message = "用户不存在",
                    Status = HttpResultStatus.Error,
                    Success = false
                };
            }
            if (user.Password != dto.Password)
            {
                await _loginLogService.Add(new Model.Entities.Mongo.LoginLogEntity()
                {
                    Status = 400,
                    UserName = dto.UserName,
                    Message = "密码错误"
                });
                return new HttpResultModel()
                {
                    Message = "密码错误",
                    Status = HttpResultStatus.Error,
                    Success = false
                };
            }

            var token = JwtHelper.GetToken(user.UserName, user.NickName);
            await _loginLogService.Add(new Model.Entities.Mongo.LoginLogEntity()
            {
                Status = 200,
                UserName = dto.UserName,
                UserId = user.UserId
            });

            return new HttpResultModel(token)
            {
                Data = token
            };
        }

        [HttpGet]
        [Route("userLogin/log")]
        [AllowAnonymous]
        public async Task<HttpResultModel> GetUserLoginLog()
        {
            var list = await _loginLogService.GetListAsync(x => 1 == 1);
            return new HttpResultModel()
            {
                Data = list
            };
        }

        [HttpDelete]
        [Route("userLogin/log")]
        [AllowAnonymous]
        public async Task<HttpResultModel> DeleteUserLoginLog()
        {
            var entity = await _loginLogService.GetAsync(x => x.Status == 400);
            await _loginLogService.Delete(entity.Id);
            return new HttpResultModel()
            {
                Message="删除成功"
            };
        }
    }
}
