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

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ConControl.DataContext = new CreateAccountView();
        //}
        private void TxbSearch_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txbSearch.Text == "Search")
                txtBox.Text = string.Empty;
        }
    }
}
