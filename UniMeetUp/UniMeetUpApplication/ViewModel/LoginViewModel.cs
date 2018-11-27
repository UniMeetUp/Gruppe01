using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;
using UniMeetUpApplication.View;

namespace UniMeetUpApplication.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public UserControl _currentPage;
   
        private ILoginModel _loginModel = new LoginModel(new ServerAccessLayer.ServerAccessLayer());
        private INotificationService _notificationService = new NotificationService();
        public LoginViewModel()
        {
            
        }

        public UserControl CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        //private ICommand _loginCommand;
        //public ICommand LoginCommand
        //{
        //    get
        //    {
        //        return _loginCommand ??
        //               (_loginCommand = new RelayCommand(() =>
        //               {
        //                   // Problem Fixed!!
        //                   var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
        //
        //                   viewModel.User.displayName = "User1";
        //                   viewModel.MainPageCommand.Execute(null);
        //
        //                   // We may need multiBinding for MasterPage swicth
        //
        //               }));
        //    }
        //}



        ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand<object>(Login));
            }
        }
        
        public async void Login(object parameter)
        {
            LoginView.spinner.Visibility = Visibility.Visible;
            var values = (object[])parameter;
            
            string Email = values[0].ToString();
            string Password = values[1].ToString();
            //string Password = values[1].ToString();
            
            UserForLogin userForLogin = new UserForLogin(Email, Password);

            var str = await _loginModel.Validate_Email_and_Password(userForLogin);

            if (str)
            {
                var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
                viewModel.MainPageCommand.Execute(null);
                
                _loginModel.getAllUserData(userForLogin.Email);
            }
            else
            {
                _notificationService.Show_Message_Email_Or_Password_Is_Incorrect();
            }
            LoginView.spinner.Visibility = Visibility.Hidden;
        }

        ICommand _createAccountBtnCommand;
        public ICommand CreateAccountBtnCommand
        {
            get
            {
                return _createAccountBtnCommand ?? (_createAccountBtnCommand = new RelayCommand(() =>
                {
                    var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
                    viewModel.CreateAccountPageCommand.Execute(null);
                }));
            }
        }

        ICommand _goToLoginScreenCommand;
        public ICommand GoToLoginScreenCommand
        {
            get
            {
                return _goToLoginScreenCommand ?? (_goToLoginScreenCommand = new RelayCommand(() =>
                {
                    var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
                    viewModel.LoginPageCommand.Execute(null);
                }));
            }
        }


        public ICommand _forgotPasswordPageCommand;
        

        public ICommand ForgotPasswordPageCommand
        {
            get
            {

                return _forgotPasswordPageCommand ?? (_forgotPasswordPageCommand = new RelayCommand(() =>
                {
                    ForgotPasswordDialog _dialogBox = new ForgotPasswordDialog();
                    _dialogBox.Owner = Application.Current.MainWindow;
                    if (_dialogBox.ShowDialog() == true)
                    {
                        //Do nothing
                        
                    }
                }));
            }
        }

       
    }
}
