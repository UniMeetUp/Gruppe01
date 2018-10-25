using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ChatLib;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task FileMessage(FileMessage file)
        {
            return Clients.All.SendAsync("FileMessage", file);
        }

    }
}
