using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLib.Models
{
    public class Waypoint
    {
        [Key]
        public int WaypointId { get; set; }

        [Required]
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public int GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
