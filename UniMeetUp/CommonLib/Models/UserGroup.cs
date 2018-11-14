using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLib.Models
{
    public class UserGroup : DbContext
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string EmailAddress { get; set; }
        public User User { get; set; }
    }
}
