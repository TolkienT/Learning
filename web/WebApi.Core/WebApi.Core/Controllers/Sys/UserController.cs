using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;
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
            return new HttpResultModel<List<UserDto>>(res);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<HttpResultModel<string>> Register([FromBody] UserRegisterDto dto)
        {
            var flag = await _userService.Register(dto);
            if (flag)
                return new HttpResultModel<string>(null);
            return new HttpResultModel<string>(null, "注册失败", HttpResultStatus.Error);
        }

        [HttpPost]
        [Route("{userId}/Update")]
        public async Task<HttpResultModel<string>> UpdateUser(string userId, [FromBody] UpdateUserDto dto)
        {
            var flag = await _userService.UpdateUser(dto);
            if (flag)
                return new HttpResultModel<string>(null);
            return new HttpResultModel<string>(null, "注册失败", HttpResultStatus.Error);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<HttpResultModel<object>> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.GetUser(x => x.UserName == dto.UserName);
            if (user is null)
                return new HttpResultModel<object>(null, "用户不存在", HttpResultStatus.Error);
            var security = await _userSecurityService.GetSecurity(x => x.UserId == user.Id);
            if (security is not null)
            {
                if (security.Password != dto.Password)
                {
                    return new HttpResultModel<object>(null, "密码错误", HttpResultStatus.Error);
                }
            }

            int expiresTime = 3600;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.GivenName, user.NickName),
                new Claim(ClaimTypes.Expiration, expiresTime.ToString())
            };

            var now = DateTime.Now;

            /*
             * iss (issuer)：签发人
             * exp (expiration time)：过期时间
             * sub (subject)：主题
             * aud (audience)：受众
             * nbf (Not Before)：生效时间
             * iat (Issued At)：签发时间
             * jti (JWT ID)：编号
             */
            var jwt = new JwtSecurityToken(
                issuer: "tang.zx",
                audience: "audience",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(expiresTime)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new HttpResultModel<object>( new
            {
                Token = token,
                ExpiresTime = expiresTime
            });
        }
    }
}
