using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class User
    {
        public User()
        {
            

        }
        public string displayName { set; get; }
        public string emailAdresse { set; get; }
        public string password { set; get; }

        // The string is for the group name
        public List<Group> groups = new List<Group>();

        public Groups groupps = new Groups();
       }
}
