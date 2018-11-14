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
}
