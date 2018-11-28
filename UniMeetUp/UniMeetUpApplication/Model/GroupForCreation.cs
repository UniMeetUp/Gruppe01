using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class GroupForCreation
    {
        public GroupForCreation(string groupname)
        {
            GroupName = groupname;
        }

        public int GroupId;
        public string GroupName { set; get; }
        public string EmailAddress { get; set; }
    }
}
