using System;
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
        public async Task SendMessage(string emailAddress, int groupId, string message)
        {
            var msg = new ChatMessage {Message = message, UserId = emailAddress, GroupId = groupId};
            _context.ChatMessage.Add(msg);
            _context.SaveChanges();
            
            await Clients.All.SendAsync("ReceiveMessage", emailAddress, message);
        }

        public Task FileMessage(string emailAddress, int groupId, FileMessage file)
        {
            file.UserId = emailAddress;
            file.GroupId = 1; 
            _context.FileMessage.Add(file);
            _context.SaveChanges();
            return Clients.All.SendAsync("FileMessage", file);
        }


    }
}
