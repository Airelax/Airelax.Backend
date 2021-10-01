using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Airelax.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            if (GetCount(groupName) == 2) return;
            UserHandler.ConnectedIds.Add(groupName);
        }

        public async Task AddAllGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageToGroup(string groupName, string obj, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", obj, message);
        }

        public async Task RemoveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            if (GetCount(groupName) == 0) return;
            UserHandler.ConnectedIds.Remove(groupName);
        }

        public async Task RemoveAllGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public static class UserHandler
        {
            public static List<string> ConnectedIds = new List<string>();
        }

        public int GetCount(string groupName)
        {
            return UserHandler.ConnectedIds.Where(x => x == groupName).ToList().Count;
        }

        public async Task OnlineStatus(string groupName, string obj)
        {
            await Clients.Group(groupName).SendAsync("ReceiveStatus", obj);
        }
    }
}
