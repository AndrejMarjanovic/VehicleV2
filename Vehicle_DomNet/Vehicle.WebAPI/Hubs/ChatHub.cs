using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Vehicle.WebAPI.Authentication;

namespace Vehicle.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly List<string> ActiveUsers = new List<string>();
        public async Task SendMessage(string user, string message)
        {
             await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UserLoggedIn(string username)
        {
            if (!ActiveUsers.Contains(username))
            {
                ActiveUsers.Add(username);
                await Clients.All.SendAsync("UpdateActiveUsers", ActiveUsers);
            }
        }

        public async Task UserLoggedOut(string username)
        {
            if (ActiveUsers.Contains(username))
            {
                ActiveUsers.Remove(username);
                await Clients.All.SendAsync("UpdateActiveUsers", ActiveUsers);
            }
        }
    }
}