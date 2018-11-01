using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ChatLib;
using ChatServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatServerContext _context;

        //Database context - has connection to database
        public ChatHub(ChatServerContext context)
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
