using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;

namespace UniMeetUpApplication.ViewModel
{
    public class CreateAccountViewModel : ViewModelBase
    {
        private readonly ICreateAccountModel _createAccountModel = new CreateAccountModel(new ServerAccessLayer.ServerAccessLayer());
        private readonly INotificationService _notificationService = new NotificationService();

        public CreateAccountViewModel()
        {
           
        }
       
        ICommand _createAccountCommand;
        public ICommand CreateAccountCommand
        {
            get
            {
                return _createAccountCommand ?? (_createAccountCommand = new RelayCommand<object>(CreateAccount));
            }
        }

        public async void CreateAccount(object parameter)
        {
            var values = (object[])parameter;

            string DisplayName = values[0].ToString();
            string Email = values[1].ToString();
            string EmailConfirm = values[2].ToString();
            string Password = values[3].ToString();
            string PasswordRepeat = values[4].ToString();

            if (Check_If_Given_Emails_Differ_And_Format_Is_Valid(Email, EmailConfirm) &&
                Check_If_Given_Passwords_Differ_And_Format_Is_Valid(Password, PasswordRepeat))
            {
                if (_createAccountModel.Validate_Email(Email))
                {
                    //_createAccountModel.Create_Account(DisplayName, Email, Password);

                    var str = await _createAccountModel.Create_Account(new UserForCreateAccount(DisplayName, Email, Password));

                    if (str == true)
                    {
                        var viewModel = (MasterViewModel)App.Current.MainWindow.DataContext;
                        viewModel.MainPageCommand.Execute(null);

                        _notificationService.Show_Message_Account_Has_Been_Created();
                    }
                    else
                    {
                        _notificationService.Show_Message_Something_went_wrong();
                    }
                    
                }
                else
                {
                    _notificationService.Show_Message_Email_Is_Already_In_Use();
                }
            }
        }

        private bool CompareTwoStrings(string a, string b)
        {
            if (a == b)
                return true;
            
            return false;
        }

        private bool Check_If_Given_Emails_Differ_And_Format_Is_Valid(string Email, string EmailConfirm)
        {
            if (Email != EmailConfirm)
            {
                _notificationService.Show_Message_Emails_Does_Not_Match();

                return false;
            }
            if (!Email.Contains("@"))
            {
                _notificationService.Show_Message_Email_Format_Is_Not_Valid();
                return false;
            }

            return true;
        }

        private bool Check_If_Given_Passwords_Differ_And_Format_Is_Valid(string Password, string PasswordRepeat)
        {
            if (Password != PasswordRepeat)
            {
                _notificationService.Show_Message_Passwords_Does_Not_Match();
                return false;
            }
            if (Password.Length < 8)
            {
                _notificationService.Show_Message_Password_Is_Too_Short();
                return false;
            }
            if (!Password.Any(char.IsUpper) || !Password.Any(char.IsDigit))
            {

                _notificationService.Show_Message_Password_Not_Containing_Uppercase_Or_Number();
                return false;
            }

            return true;
        }
    }
}
