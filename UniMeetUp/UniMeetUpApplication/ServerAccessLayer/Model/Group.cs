using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    
    public class Group
    {
        public Group()
        {

        }

        public Group(string Groupname)
        {
            groupName = Groupname;
        }



        public string groupName{ get; set; }

        // string is email
        private List<string> _membersList;

        //private List<Location> _locationsList;
        //
        //private List<WayPoint> _wayPointsList;

        //  the string is the email of the user/member
        //private Dictionary<string, User> users;

        private List<Message> messages;

    }
}
