using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLib.Models
{
    public class UserGroup
    {

        //protected override void OnModelCreating(Modelbuilder modelbuilder)
        //{

        //}

        [Key]
        public int UserGroupId { get; set; }

       
        public int GroupId { get; set; }
        public Group Group { get; set; }

        
        public string EmailAddress { get; set; }
        public User User { get; set; }
    }


}
