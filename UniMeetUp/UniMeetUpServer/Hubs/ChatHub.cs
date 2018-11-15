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
            
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", emailAddress, message);
        }

        public Task FileMessage(string emailAddress, int groupId, FileMessage file)
        {
            file.UserId = emailAddress;
            file.GroupId = 1; 
            _context.FileMessage.Add(file);
            _context.SaveChanges();
            return Clients.Group(groupId.ToString()).SendAsync("FileMessage", file);
        }

        //Joing a group SignalR style.
        public async Task JoinGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());

            System.Console.WriteLine($"Client joined room: {groupId.ToString()}");
            //return Groups.Add(Context.ConnectionId, roomName);
        }

        //Adding a User to a Group on the DB.
        public async Task AddUserToGroupViaUserGroup(string emailAddress, int groupId)
        {
            //Create new UserGroup
            UserGroup UserGroup = new UserGroup();

            //Set the UserGroups Composite key, made up of current users emailaddress and newly created groups ID
            UserGroup.EmailAddress = emailAddress;
            UserGroup.GroupId = groupId;

            //Add the reference to Usergroup collections in User and Group
            UserGroup.User.UserGroups.Add(UserGroup);
            UserGroup.Group.UserGroups.Add(UserGroup);
        }

        public async Task LeaveGroup(int groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());

            System.Console.WriteLine($"Client left room: {groupId.ToString()}");
            //return Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}
