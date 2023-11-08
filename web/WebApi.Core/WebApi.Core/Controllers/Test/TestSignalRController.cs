using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Common.Hubs;
using WebApi.Model.Models;

namespace WebApi.Core.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestSignalRController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public TestSignalRController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [Route("Test")]
        public async Task<HttpResultModel> TestSendMessage()
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
            await _hubContext.Clients.All.SendAsync("TestSignalR", list);
            return new HttpResultModel()
            {
                Success = true,
                Status = Model.Enums.HttpResultStatus.OK
            };
        }




    }
}
