using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class WayPoint
    {
        public int LocationId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }

        public int GroupId { get; set; }

        public string Description { get; set; }

    }
}
