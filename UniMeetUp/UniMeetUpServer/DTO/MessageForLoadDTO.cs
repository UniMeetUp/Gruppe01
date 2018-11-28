using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMeetUpServer.DTO
{
    public class MessageForLoadDTO
    {
        public MessageForLoadDTO(string userId, string message)
        {
            UserId = userId;
            Message = message;
        }
        public string UserId { get; set; }
        public string Message { get; set; }
    }
}
