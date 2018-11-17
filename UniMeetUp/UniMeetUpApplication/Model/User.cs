using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Annotations;

namespace UniMeetUpApplication.Model
{
    public class User : INotifyPropertyChanged
    {
        public User()
        {
            _groups = new Groups();
            _groups.Add(new Group("TESTGRUPPE", 99));
            
        }

        private string _displayName;
        public string DisplayName
        {
            set
            {
                _displayName = value;
                OnPropertyChanged("DisplayName");
            }
            get { return _displayName; }
        }


        public string emailAdresse { set; get; }
        public string password { set; get; }

        // The string is for the group name
        //private List<Group> _groups;
        //public List<Group> Groups
        //{
        //    get { return _groups; }
        //    set { _groups = value; OnPropertyChanged("Groups");}
        //}

        public Groups _groups;

        public Groups Groups
        {
            get { return _groups;}
            set { _groups = value; OnPropertyChanged("Groups"); }
        }
        
        



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
    }
}
