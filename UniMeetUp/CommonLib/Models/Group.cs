using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
