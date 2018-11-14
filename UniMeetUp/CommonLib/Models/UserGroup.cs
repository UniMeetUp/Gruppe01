//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;

//namespace CommonLib.Models
//{
//    public class UserGroup : DbContext
//    {
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<UserGroup>()
//                .HasKey(t => new { t.EmailAddress, t.GroupId });

//            modelBuilder.Entity<UserGroup>()
//                .HasOne(uc => uc.User)
//                .WithMany(u => u.UserGroups)
//                .HasForeignKey(uc => uc.EmailAddress);

//            modelBuilder.Entity<UserGroup>()
//                .HasOne(uc => uc.Group)
//                .WithMany(g => g.UserGroups)
//                .HasForeignKey(uc => uc.GroupId);
//        }
        
        
//        public int GroupId { get; set; }
//        public Group Group { get; set; }
        
//        public string EmailAddress { get; set; }
//        public User User { get; set; }
//    }
//}
