using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.WPF;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;


namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private ILoginModel _loginModel = new LoginModel(new ServerAccessLayer.ServerAccessLayer());
        private INotificationService _notificationService = new NotificationService();

        public static ImageAwesome spinner;

        // Here we create the viewmodel with the current DialogCoordinator instance 

        public LoginView()
        {
            InitializeComponent();
            spinner = MySpinner;
        }

        private void passwordBx_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = passwordBx.Password;
        }

        private void PasswordBx_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tbPassword.Text = passwordBx.Password;
            }
        }

        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 14.0;
        }
    }
}
