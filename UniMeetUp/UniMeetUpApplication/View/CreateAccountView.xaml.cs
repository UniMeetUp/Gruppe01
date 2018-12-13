using System;
using System.Windows;
using System.Windows.Controls;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for CreateAccountView.xaml
    /// </summary>
    public partial class CreateAccountView : UserControl
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 14.0;
        }
   
        private void PasswordHack1(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = PasswordBx1.Password;
        }
        private void PasswordHack2(object sender, RoutedEventArgs e)
        {
            tbPasswordRepeat.Text = PasswordBx2.Password;
        }

        private void mustBeChecked(object sender, RoutedEventArgs e)
        {
            
            if (CheckBox.IsChecked == false)
            {
                createAccBttn.IsEnabled = false;
            }
            else
            {
                createAccBttn.IsEnabled = true;
            }
        }
    }
}
