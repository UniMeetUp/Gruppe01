using System;

namespace UniMeetUpApplication.Model
{
    public class Message
    {
        public string message{ get; set; }
        public User Sender { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
