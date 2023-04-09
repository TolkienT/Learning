using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiDemo.Model;
using WebApiDemo.Model.Models;
using WebApiDemo.Services.IServices;
using WebApiDemo.Services.IServices.Base;
using WebApiDemo.Services.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AreaController
    {
        private readonly IBaseService<AreaModel> _areaService;
        //private readonly IAreaService _areaService;
        public AreaController(IBaseService<AreaModel> areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<ResponseModel<string>> Test()
        {
            if (await _areaService.Add(new AreaModel() { Id = 1,AreaCode="1",AreaName="China" }))
                return new ResponseModel<string>("success", null);
            return new ResponseModel<string>("error", null);
        }
    }
}
