using System;

namespace UniMeetUpApplication.Model
{
    public class UserLocation
    {
        public int LocationId{ get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId{ get; set; }
        public int GroupId{ get; set; }
    }
}
