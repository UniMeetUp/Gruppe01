using CommonLib.Models;
using Microsoft.EntityFrameworkCore;

namespace UniMeetUpServer.Data
{
    public class UniMeetUpContext : DbContext
    {
        public UniMeetUpContext(DbContextOptions<UniMeetUpContext> options)
            : base(options)
        {
        }
        
        public DbSet<ChatMessage> ChatMessage { get; set; }
        
        public DbSet<CommonLib.Models.FileMessage> FileMessage { get; set; }
        
        public DbSet<CommonLib.Models.User> User { get; set; }
        
        public DbSet<CommonLib.Models.Group> Group { get; set; }
    }
}
