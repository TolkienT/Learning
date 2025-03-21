using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Net.WebSockets;
using System.Text;
using WebServer.Cache;
using WebServer.Filter;
using WebServer.Model.Models;

namespace WebServer.Core.Controllers.Test
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WebsocketController : ControllerBase
    {
        [HttpGet]
        public async Task<HttpResultModel> TestWriteMsg(string key)
        {
            foreach (var connection in RunTimeSharedData.WebSocketConnections)
            {
                var message = $"当前key:{connection.Key},Broadcast message: {DateTime.UtcNow};发送消息:{key}";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                await connection.Value.SendAsync(
                    new ArraySegment<byte>(messageBytes),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }

            return new HttpResultModel()
            {
                Status = Model.Enums.HttpResultStatus.OK,
                Success = true
            };
        }



    }
}
