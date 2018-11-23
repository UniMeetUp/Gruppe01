using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;

namespace UniMeetUpApplication.Model
{
    public class Groups : ObservableCollection<Group>
    {
        public Groups()
        {

        }

        #region Commands



        ICommand _addMemberToGroupCommand;

        public ICommand AddMemberToGroupCommand
        {
            get{
                return _addMemberToGroupCommand ?? (_addMemberToGroupCommand = new RelayCommand(() =>
                {

                }));
            }
        }



        #endregion
    }
}
