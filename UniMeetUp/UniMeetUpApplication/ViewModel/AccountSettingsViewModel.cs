using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;

namespace UniMeetUpApplication.ViewModel
{
    public class AccountSettingsViewModel
    {


        ICommand _logOutCommand;
        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand(logOutCommandExe));
            }
        }

        public void logOutCommandExe()
        {
            MasterViewModel _masterViewModel = ((MasterViewModel) App.Current.MainWindow.DataContext);
            User _userHack = new User();
           

            _masterViewModel.User = _userHack;

            _masterViewModel.LoginPageCommand.Execute(null);

        }
    }
}
