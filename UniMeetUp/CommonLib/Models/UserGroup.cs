using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLib.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }

        public ICollection<User> Users { get; } = new List<User>();
    }

    public class User
    {
        [Key]
        public string EmailAddress { get; set; }

        [Required]
        public string HashedPassword { get; set; }
        [MaxLength(25)]
        public string DisplayName { get; set; }

        public ICollection<Group> Groups { get; } = new List<Group>();
    }

    public class UserGroup
    {
        public int UserGroupId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string EmailAddress { get; set; }
        public User User { get; set; }
    }
}
