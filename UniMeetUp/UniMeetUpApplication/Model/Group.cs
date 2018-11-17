using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Annotations;

namespace UniMeetUpApplication.Model
{
    
    public class Group
    {

        
        public Group()
        {

        }

        public Group(string groupName, int groupId)
        {
            GroupName = groupName;
            GroupId = groupId;
        }

        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value; 
                OnPropertyChanged("Groupname");
            }
        }

        private int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set
            {
                _groupId = value;
                OnPropertyChanged("GroupId");
            }
        }

        
        
        private List<string> _membersList { get; set; }
        private List<Message> messages { get; set; }

        //private List<Location> _locationsList;
        //
        //private List<WayPoint> _wayPointsList;

        //  the string is the email of the user/member
        //private Dictionary<string, User> users;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
