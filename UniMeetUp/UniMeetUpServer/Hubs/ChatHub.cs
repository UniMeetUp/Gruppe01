using System.Threading.Tasks;
using CommonLib.Models;
using Microsoft.AspNetCore.SignalR;
using UniMeetUpServer.Models;

namespace UniMeetUpServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UniMeetUpServerContext _context;

        //Database context - has connection to database
        public ChatHub(UniMeetUpServerContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string user, string message)
        {
            var msg = new ChatMessage {Message = message};
            _context.ChatMessage.Add(msg);
            _context.SaveChanges();
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public Task FileMessage(FileMessage file)
        {
            _context.FileMessage.Add(file);
            _context.SaveChanges();
            return Clients.All.SendAsync("FileMessage", file);
        }

    }
}
