using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.IService.Auth;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private static IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(
            IMapper mapper,
            IRoleService roleService
            )
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        [Route("Query")]
        [AllowAnonymous]
        public async Task<HttpResultModel<object>> Query()
        {
            var users = await _roleService.Query();

            return new HttpResultModel<object>(users);
        }
    }
}
