using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class AddMemberGroup
    {
        public AddMemberGroup(string emailAddress, int groupId)
        {
            EmailAddress = emailAddress;
            GroupId = groupId;
        }

        public string EmailAddress { get; set; }
        public int GroupId{ get; set; }
    }
}
