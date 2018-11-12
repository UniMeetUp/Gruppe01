using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
        public List<User> Users { get; set; }
    }
}
