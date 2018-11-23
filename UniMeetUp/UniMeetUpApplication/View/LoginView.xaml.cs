using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using FontAwesome.WPF;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.Services;
using UniMeetUpApplication.Services.ServiceInterfaces;
using UniMeetUpApplication.ViewModel;


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
        public LoginView()
        {
            InitializeComponent();
            spinner = MySpinner;

        }

        //private void PasswordIsSentToTxtBx(object sender, TextCompositionEventArgs e)
        //{
        //    tbPassword.Text = passwordBx.Password;
        //}

        private void passwordBx_LostFocus(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = passwordBx.Password;
        }

      
    }
}
