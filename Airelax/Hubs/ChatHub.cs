using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.AspNetCore.SignalR;

namespace Airelax.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
        }

        public async Task SendMessageToGroup(string groupName, string username, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", username, message);
        }

        public async Task RemoveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
        }

        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

        public int getCount()
        {
            return UserHandler.ConnectedIds.Count;
        }
    }
}
