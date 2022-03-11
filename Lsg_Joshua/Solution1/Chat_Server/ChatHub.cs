using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

using Microsoft.AspNet.SignalR;

namespace Chat_Server
{
    public class ChatHub : Hub
    {


        public void SendeAnAlle(string text)
        {
            Clients.Others.Empfange(text);
        }

        public void SendeAnUser(string empfaenger, string text)
        {
            Clients.Group(empfaenger).Empfange(text);

          
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);
        }

        

    }
}