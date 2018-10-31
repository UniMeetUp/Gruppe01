using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatLib;

namespace ChatServer.Models
{
    public class ChatServerContext : DbContext
    {
        public ChatServerContext (DbContextOptions<ChatServerContext> options)
            : base(options)
        {
        }
        
        public DbSet<ChatMessage> ChatMessage { get; set; }
        
        public DbSet<ChatLib.FileMessage> FileMessage { get; set; }
        
        public DbSet<ChatLib.User> User { get; set; }
        
        public DbSet<ChatLib.Group> Group { get; set; }
    }
}
