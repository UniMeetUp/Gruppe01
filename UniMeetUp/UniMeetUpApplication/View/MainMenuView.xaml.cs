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
using UniMeetUpApplication.View.Dialogs;
using UniMeetUpApplication.ViewModel;

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

            // Lille test til at skrive en besked om at brugeren ikke er i nogen gruppe.
            //if (((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.Count == 0)
            //{
            //    lNoCurrentGroups.Visibility = Visibility.Visible;
            //    lbGroups.Visibility = Visibility.Hidden;
            //}

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddGroupDialog _dialogBox = new AddGroupDialog();
            if (_dialogBox.ShowDialog() == true)
            {
                //something
            }
        }

        private void searchLostFocus(object sender, RoutedEventArgs e)
        {
            if (txbSearch.Text == "")
            {
                txbSearch.Text = "Search for group...";
                txbSearch.Foreground = Brushes.LightGray;

            }
        }

        private void searchGotFocus(object sender, RoutedEventArgs e)
        {
            if (txbSearch.Text == "Search for group...")
            {
                txbSearch.Text = "";
                txbSearch.Foreground = Brushes.Black;

            }
        }

        private void txbSearch_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            if (txbSearch.Text == "Search for group...")
                txbSearch.Text = string.Empty;
        }
    }
}
