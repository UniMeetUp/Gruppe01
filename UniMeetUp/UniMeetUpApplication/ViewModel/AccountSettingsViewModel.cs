using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            MainWindow.MasterViewModel.Height = 550;
            MainWindow.MasterViewModel.Width = 1000;
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = App.Current.MainWindow.Width;
            double windowHeight = App.Current.MainWindow.Height;

            App.Current.MainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            App.Current.MainWindow.Top = (screenHeight / 2) - (windowHeight / 2);

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
            MessageBoxResult result = MessageBox.Show("By doing this, your account will be permantly deleted", "Delete account", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (await asm.Delete_account(user))
                    {
                        viewModel.LoginPageCommand.Execute(null);
                        MainWindow.MasterViewModel.Height = 550;
                        MainWindow.MasterViewModel.Width = 1000;
                        double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                        double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
                        double windowWidth = App.Current.MainWindow.Width;
                        double windowHeight = App.Current.MainWindow.Height;

                        App.Current.MainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
                        App.Current.MainWindow.Top = (screenHeight / 2) - (windowHeight / 2);

                    }
                    else
                    {
                        _notificationService.Show_Message_Something_went_wrong();
                    }

                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    // ...
                    break;
                case MessageBoxResult.Cancel:
                    // User pressed Cancel button
                    // ...
                    break;
            }

           
        }

        ICommand _goBackToMainMenu;
        public ICommand GoBackToMainMenu
        {
            get
            {
                return _goBackToMainMenu ?? (_goBackToMainMenu = new RelayCommand(goBackToMainMenu));
            }
        }

        public void goBackToMainMenu()
        {
            var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
            viewModel.MainPageCommand.Execute(null);


        }
    }
}
