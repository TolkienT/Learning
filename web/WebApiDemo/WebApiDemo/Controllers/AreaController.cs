using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo.Model;
using WebApiDemo.Services.IServices;
using WebApiDemo.Services.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AreaController
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<ResponseModel<string>> Test()
        {
            return new ResponseModel<string>("success", _areaService.Test());
        }
    }
}
