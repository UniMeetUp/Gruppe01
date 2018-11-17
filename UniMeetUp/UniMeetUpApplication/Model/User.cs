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
        public List<Group> groups = new List<Group>();


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
