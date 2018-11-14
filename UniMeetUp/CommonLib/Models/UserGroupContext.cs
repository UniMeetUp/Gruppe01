using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CommonLib.Models
{
    class MyContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(t => new { t.EmailAddress, t.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(uc => uc.EmailAddress);

            modelBuilder.Entity<UserGroup>()
                .HasOne(uc => uc.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(uc => uc.GroupId);
        }
    }

    public class User
    {
        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public string HashedPassword { get; set; }
        [MaxLength(25)]
        public string DisplayName { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    }

    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    }

    public class UserGroup
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string EmailAddress { get; set; }
        public User User { get; set; }
    }
}
