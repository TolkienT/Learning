using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetWeighBridgeAlarm(string user, string message)
        {
            await Clients.All.SendAsync("地磅故障信息", TestHandler.GetWeighBridgeAlarm().Result);
        }
    }
}
