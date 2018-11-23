using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Annotations;
using UniMeetUpApplication.Command;

namespace UniMeetUpApplication.Model
{
    public class Groups : ObservableCollection<Group>
    {
        public Groups()
        {

        }

        #region Commands

        Group currentGroup;

        public Group CurrentGroup
        {
            get
            {
                if (currentGroup == null)
                {
                    return new Group("", 0);
                }
                return currentGroup;
            }
            set
            {
                if (currentGroup != value)
                {
                    currentGroup = value;
                    OnPropertyChanged("CurrentGroup");
                }
            }
        }

        ICommand _addMemberToGroupCommand;

        public ICommand AddMemberToGroupCommand
        {
            get{
                return _addMemberToGroupCommand ?? (_addMemberToGroupCommand = new RelayCommand(() =>
                {

                }));
            }
        }

        #region NotifypropertyChange
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


        #endregion




        #endregion
    }
}
