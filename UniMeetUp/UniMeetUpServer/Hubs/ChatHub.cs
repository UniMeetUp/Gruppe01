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
            var user = _context.User.Find(emailAddress);
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", emailAddress, user.DisplayName, message);
        }

        public void FileMessage(string emailAddress, int groupId, FileMessage file)
        {
            file.UserId = emailAddress;
            file.GroupId = groupId; 
            _context.FileMessage.Add(file);
            _context.SaveChanges();
        }
        
        //Joing a group SignalR style.
        public async Task JoinGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
        }

        public async Task LeaveGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
        }
    }
}
