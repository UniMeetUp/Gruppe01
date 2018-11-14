using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLib.Models
{
    public class UserGrou
    {

        protected override void OnModelCreating(Modelbuilder modelbuilder)
        {

        }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("User")]
        public string EmailAddress { get; set; }
        public User User { get; set; }
    }


}
