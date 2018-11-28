using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class Message
    {

        public string message{ get; set; }

        
        public User Sender { get; set; }


        public DateTime timeStamp { get; set; }
    }
}
