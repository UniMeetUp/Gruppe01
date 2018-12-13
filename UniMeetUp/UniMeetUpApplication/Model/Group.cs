using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        private List<string> _membersList = new List<string>();
        public List<string> MemberList
        {
            get
            {
                return _membersList;
            }
            set
            {
                _membersList = value;
                OnPropertyChanged("MemberList");
            }
        }
        private List<Message> messages { get; set; }
        private List<FileMessageForFileFolder> _listOfFilesInGroup;

        public List<FileMessageForFileFolder> ListOfFilesInGroup
        {
            get { return _listOfFilesInGroup; }
            set
            {
                _listOfFilesInGroup = value;
                OnPropertyChanged("ListOfFilesInGroup");
            }
        }

        #region NotifypropertyChanged Impl

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion
    }
}
