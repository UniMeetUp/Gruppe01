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
        string UserId { get; set; }
        string Message { get; set; }
    }
}
