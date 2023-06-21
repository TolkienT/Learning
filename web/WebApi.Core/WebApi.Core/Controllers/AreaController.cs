using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.IService.User;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AreaController
    {
        private readonly IAreaService _areaService;
        //private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        [Route("AddArea")]
        public async Task<HttpResultModel<string>> Add(double? test)
        {
            if (await _areaService.Add(new AreaEntity() { AreaCode = "1", AreaName = "China", TestDouble = test }))
                return new HttpResultModel<string>("success", null);
            return new HttpResultModel<string>("error", null);
        }

        [HttpGet]
        public async Task<HttpResultModel<IEnumerable<AreaEntity>>> Query([FromQuery] UserQueryInput input)
        {
            var res = await _areaService.Query(x => x.AreaCode == input.AreaCode);
            return new HttpResultModel<IEnumerable<AreaEntity>>("error", res);
        }
    }
}
