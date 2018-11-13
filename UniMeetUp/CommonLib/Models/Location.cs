using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime TimeStamp { get; set; }

        public string UserId { get; set; }
        public int GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
