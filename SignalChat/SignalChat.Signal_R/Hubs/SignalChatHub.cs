using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalChat.Domain.Model;

namespace SignalChat.Signal_R.Hubs
{
    public class SignalChatHub : Hub
    {
        public async Task SendSignalMessage(string user, SignalChatMessage msg)
        {
            await Clients.All.SendAsync("ReceiveSignalMessage", user, msg);
        }
    }
}
