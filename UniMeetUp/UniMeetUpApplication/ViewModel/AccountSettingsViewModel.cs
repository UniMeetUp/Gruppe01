using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
namespace UniMeetUpApplication.ViewModel
{
    public class AccountSettingsViewModel
    {
        AccountSettingsModel asm = new AccountSettingsModel();
        private INotificationService _notificationService = new NotificationService();

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

        
        ICommand _deleteAccountCommand;
        public ICommand DeleteAccountCommand
        {
            get
            {
                return _deleteAccountCommand ??
                       (_deleteAccountCommand = new RelayCommand(deleteAccount));
            }
        }

        public async void deleteAccount()
        {
            var viewModel = (MasterViewModel) App.Current.MainWindow.DataContext;

            var user = viewModel.User;

            if (await asm.Delete_account(user))
            {
                viewModel.LoginPageCommand.Execute(null);
            }
            else
            {
                _notificationService.Show_Message_Something_went_wrong();
            }
        }
    }
}
