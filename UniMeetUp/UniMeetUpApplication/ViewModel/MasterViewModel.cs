using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.View;

namespace UniMeetUpApplication.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        // start up screen
        public UserControl _currentMasterPage = new LoginView();
        
        private User _user = new User();
        
        
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public UserControl CurrentMasterPage
        {
            get { return _currentMasterPage; }
            set
            {
                _currentMasterPage = value;
                OnPropertyChanged("CurrentMasterPage");
            }
        }

        private ICommand _loginPageCommand;
        public ICommand LoginPageCommand
        {
            get
            {
                return _loginPageCommand ??
                       (_loginPageCommand = new RelayCommand(() =>
                       {
                           CurrentMasterPage = new LoginView();
                           
                       }));
            }
        }

        private ICommand _mainMenuPageCommand;
        public ICommand MainPageCommand
        {
            get
            {
                return _mainMenuPageCommand ??
                       (_mainMenuPageCommand = new RelayCommand(() =>
                       {
                           CurrentMasterPage = new MainMenuView();

                       }));
            }
        }

        private ICommand _createAccountPageCommand;
        public ICommand CreateAccountPageCommand
        {
            get
            {
                return _createAccountPageCommand ??
                       (_createAccountPageCommand = new RelayCommand(() =>
                       {
                           CurrentMasterPage = new CreateAccountView();

                       }));
            }
        }

        //public ICommand _forgotPasswordPageCommand;

        //public ICommand ForgotPasswordPageCommand
        //{
        //    get
        //    {
        //        return _forgotPasswordPageCommand?? 
        //    }
        //}

    }
}
