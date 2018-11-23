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

namespace UniMeetUpApplication.ViewModel
{
    class AccountSettingsViewModel
    {
        AccountSettingsModel asm = new AccountSettingsModel();
        private INotificationService _notificationService = new NotificationService();
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
            var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;

            var user = viewModel.User;

            if ( await asm.Delete_account(user))
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
