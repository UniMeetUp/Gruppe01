using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMeetUpServer.DTO
{
    public class UserToPostDTO
    {
        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }

        public string DisplayName { get; set; }
    }
}
