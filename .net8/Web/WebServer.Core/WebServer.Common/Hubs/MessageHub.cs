using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Common.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string method, string message)
        {
            await Clients.All.SendAsync(method, message);
        }



    }
}
