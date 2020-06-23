using EventWorld.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EventWorld.Web.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
