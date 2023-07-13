using Microsoft.AspNetCore.Mvc;
using WebApi.Model.Dtos.Sys;
using WebApi.Model.Entities;
using WebApi.Model.Enums;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController
    {
        [HttpGet]
        [Route("Test")]
        public async Task<HttpResultModel<IEnumerable<object>>> TestGet()
        {
            List<object> list = new();
            list.Add(new
            {
                Id = 1,
                Name = "Jack"
            });
            list.Add(new
            {
                Id = 2,
                Name = "Rose"
            });
            return new HttpResultModel<IEnumerable<object>>(list);
        }

        [HttpPost]
        [Route("TestPost")]
        public async Task<HttpResultModel<object>> TestPost([FromBody] object dto)
        {
            return new HttpResultModel<object>(dto);
        }



    }
}
