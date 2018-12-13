using Microsoft.EntityFrameworkCore;

namespace UniMeetUpServer.Models
{
    public class UniMeetUpServerContext : DbContext
    {
        public UniMeetUpServerContext (DbContextOptions<UniMeetUpServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommonLib.Models.UserGroup>()
                .HasKey(t => new { t.EmailAddress, t.GroupId });

            modelBuilder.Entity<CommonLib.Models.UserGroup>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(uc => uc.EmailAddress);

            modelBuilder.Entity<CommonLib.Models.UserGroup>()
                .HasOne(uc => uc.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(uc => uc.GroupId);
        }

        public DbSet<CommonLib.Models.ChatMessage> ChatMessage { get; set; }
        public DbSet<CommonLib.Models.FileMessage> FileMessage { get; set; }
        public DbSet<CommonLib.Models.Group> Group { get; set; }
        public DbSet<CommonLib.Models.Location> Location { get; set; }
        public DbSet<CommonLib.Models.User> User { get; set; }
        public DbSet<CommonLib.Models.Waypoint> Waypoint { get; set; }
        public DbSet<CommonLib.Models.UserGroup> UserGroup { get; set; }
    }
}
