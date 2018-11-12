using Microsoft.EntityFrameworkCore;

namespace UniMeetUpServer.Models
{
    public class UniMeetUpServerContext : DbContext
    {
        public UniMeetUpServerContext (DbContextOptions<UniMeetUpServerContext> options)
            : base(options)
        {
        }

        public DbSet<CommonLib.Models.ChatMessage> ChatMessage { get; set; }

        public DbSet<CommonLib.Models.FileMessage> FileMessage { get; set; }

        public DbSet<CommonLib.Models.Group> Group { get; set; }

        public DbSet<CommonLib.Models.Location> Location { get; set; }

        public DbSet<CommonLib.Models.User> User { get; set; }

        public DbSet<CommonLib.Models.Waypoint> Waypoint { get; set; }
    }
}
