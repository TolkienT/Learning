using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Hubs
{
    public class MessageHub:Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(user, message);
        }

    }
}
