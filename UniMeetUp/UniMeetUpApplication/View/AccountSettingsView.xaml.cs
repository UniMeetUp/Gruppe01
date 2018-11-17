using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommonLib.Models;
using UniMeetUpApplication.ViewModel;


namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for AccountSettingsView.xaml
    /// </summary>
    public partial class AccountSettingsView : UserControl
    {
        
         User _user = new User();
        public AccountSettingsView()
        {
            InitializeComponent();
           
        }

        private void validateInput(object sender, TextChangedEventArgs e)
        {
            string _userPassword = ((MasterViewModel) App.Current.MainWindow.DataContext).User.password;

            if (currentPassword.Text == _userPassword)
            {
                currentPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
            }
            else
            {
                currentPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }


        private void NewPasswordRepeat_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (newPasswordRepeat.Text == newPassword.Text && newPassword.Text == newPasswordRepeat.Text)
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
                newPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
            }
            else
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        private void NewPassword_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (newPasswordRepeat.Text == newPassword.Text && newPassword.Text == newPasswordRepeat.Text)
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
                newPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
            }
            else
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }



 
        private void CurrentPasswordHasFocus(object sender, RoutedEventArgs e)
        {
            if (currentPassword.Text == "Type current password...")
            {
                currentPassword.Text = "";
                currentPassword.Foreground = Brushes.Black;

            }
           
        }

        private void CurrentPasswordHasLostFocus(object sender, RoutedEventArgs e)
        {
            if (currentPassword.Text == "")
            {
                currentPassword.Text = "Type current password...";
                currentPassword.Foreground = Brushes.LightGray;

            }
        }
    }
}
