using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class User
    {
        [Key][EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string HashedPassword { get; set; }
        [MaxLength(25)]
        public string DisplayName { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
