using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLib.Models
{
    class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
