using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class MessageForLoad
    {
        public MessageForLoad(string userId, string message)
        {
            UserId = userId;
            Message = message;
        }
        public string UserId { get; set; }
        public string Message { get; set; }
    }
}

