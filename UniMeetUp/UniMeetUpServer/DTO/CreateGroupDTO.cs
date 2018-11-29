using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniMeetUpServer.DTO
{
    public class CreateGroupDTO
    {
        public int GroupId { get; set; }
        public string EmailAddress { get; set; }
        public string GroupName { set; get; }
    }
}
