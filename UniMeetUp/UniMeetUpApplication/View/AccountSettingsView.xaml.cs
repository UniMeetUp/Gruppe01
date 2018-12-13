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

        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 14.0;
        }

        private void validateInput(object sender, RoutedEventArgs e)
        {
            string _userPassword = ((MasterViewModel)App.Current.MainWindow.DataContext).User.password;

            if (currentPassword.Password == _userPassword)
            {
                currentPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
            }
            else
            {
                currentPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        private void newPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (newPassword.Password == newPasswordRepeat.Password && newPasswordRepeat.Password == newPassword.Password
                && newPassword.Password != "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
                newPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;

                SaveBttn.IsEnabled = true;
                hiddenRe.Opacity = 0;
                hiddenNew.Opacity = 0;
            }
            else if (newPassword.Password != "" || newPassword.Password != newPasswordRepeat.Password)
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;

                SaveBttn.IsEnabled = false;
                hiddenRe.Opacity = 100;
                hiddenNew.Opacity = 100;
            }
        }

        private void repeatPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (newPasswordRepeat.Password == newPassword.Password && newPassword.Password == newPasswordRepeat.Password
                && newPasswordRepeat.Password != "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
                newPassword.BorderBrush = System.Windows.Media.Brushes.LimeGreen;
                hiddenRe.Opacity = 0;
                hiddenNew.Opacity = 0;
                SaveBttn.IsEnabled = true;
            }
            else if (newPasswordRepeat.Password != "" || newPassword.Password != newPasswordRepeat.Password)
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;

                SaveBttn.IsEnabled = false;
                hiddenRe.Opacity = 100;
                hiddenNew.Opacity = 100;
            }
        }

        private void currentPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (currentPassword.Password == "")
            {
                currentPassword.BorderBrush = System.Windows.Media.Brushes.LightGray;
            }
            else if (newPassword.Password == "" && newPasswordRepeat.Password == "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenNew.Opacity = 0;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenRe.Opacity = 0;
            }
        }

        private void newPasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (newPassword.Password == "")
            {
                newPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenRe.Opacity = 0;

            }
            else if (newPassword.Password == "" && newPasswordRepeat.Password != "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;

                SaveBttn.IsEnabled = false;
                hiddenRe.Opacity = 100;
                hiddenNew.Opacity = 100;
            }
        }

        private void repeatNewpasswordLostFocus(object sender, RoutedEventArgs e)
        {
            if (newPasswordRepeat.Password == "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenNew.Opacity = 0;

            }
            else if (newPassword.Password != "" && newPasswordRepeat.Password == "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Red;
                newPassword.BorderBrush = System.Windows.Media.Brushes.Red;

                SaveBttn.IsEnabled = false;
                hiddenRe.Opacity = 100;
                hiddenNew.Opacity = 100;
            }
        }

        private void newPasswordGotFocus(object sender, RoutedEventArgs e)
        {
            if (newPasswordRepeat.Password == "")
            {
                newPasswordRepeat.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenNew.Opacity = 0;
            }
        }

        private void repeatNewPasswordGotFocus(object sender, RoutedEventArgs e)
        {
            if (newPassword.Password == "")
            {
                newPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
                hiddenRe.Opacity = 0;
            }
        }
    }
}
