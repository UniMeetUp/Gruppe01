using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.View.Dialogs;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        Clock clock = new Clock();
        DispatcherTimer timer = new DispatcherTimer();
        private MasterViewModel masterViewModel = new MasterViewModel();

        

        public MainMenuView()
        {
            InitializeComponent();
       



            spClock.DataContext = clock;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

          
            // Lille test til at skrive en besked om at brugeren ikke er i nogen gruppe.
            //if (((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.Count == 0)
            //{
            //    lNoCurrentGroups.Visibility = Visibility.Visible;
            //    lbGroups.Visibility = Visibility.Hidden;
            //}

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
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

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            AddGroupDialog _dialogBox = new AddGroupDialog();
            if (_dialogBox.ShowDialog() == true)
            {
                
            }
        }

        //private void searchLostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (txbSearch.Text == "")
        //    {
        //        txbSearch.Text = "Search for group...";
        //        txbSearch.Foreground = Brushes.LightGray;

        //    }
        //}

        //private void searchGotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (txbSearch.Text == "Search for group...")
        //    {
        //        txbSearch.Text = "";
        //        txbSearch.Foreground = Brushes.Black;

        //    }
        //}

        //private void txbSearch_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
            
        //    if (txbSearch.Text == "Search for group...")
        //        txbSearch.Text = string.Empty;
        //}


        private void LbGroups_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MasterViewModel)App.Current.MainWindow.DataContext).User._groups.CurrentGroup =
                ((Group)lbGroups.Items.CurrentItem);

            MainMenuViewModel model = (MainMenuViewModel)TryFindResource("MainMenuViewModel");
            model.MapCommand.Execute(null);

           
            GroupMembers.Items.Clear();
            foreach (var item in ((MasterViewModel)App.Current.MainWindow.DataContext).User._groups.CurrentGroup.MemberList)
            {
                GroupMembers.Items.Add(item);
            }
        }





        private void FontLarge(object sender, RoutedEventArgs e)
        {
            FontSize = 14.0;
        }

        private void FontSmall(object sender, RoutedEventArgs e)
        {
            FontSize = 10.0;
        }

        private void FontHuge(object sender, RoutedEventArgs e)
        {
            FontSize = 16.0;
        }

        private void FontNormal(object sender, RoutedEventArgs e)
        {
            FontSize = 12.0;
        }


     

        private void disabelChatBeforeInGroup(object sender, RoutedEventArgs e)
        {
            if (groupCount.Content.Equals(0))
            {
                chatBttn.IsEnabled = false;
                MainMenuViewModel model = (MainMenuViewModel)TryFindResource("MainMenuViewModel");
                model.DisabledViewCommand.Execute(null);
                    
            }
            else
            {
                chatBttn.IsEnabled = true;
                MainMenuViewModel model = (MainMenuViewModel)TryFindResource("MainMenuViewModel");
                model.MapCommand.Execute(null);
            }

        }

        private void disableMapsBeforeINGroup(object sender, RoutedEventArgs e)
        {

            if (groupCount.Content.Equals(0))
            {
                mapsBttn.IsEnabled = false;
            }
            else
            {
                mapsBttn.IsEnabled = true;
            }
        }

        private void disableAddBeforeInGroup(object sender, RoutedEventArgs e)
        {
            if (groupCount.Content.Equals(0))
            {
                AddBttn.IsEnabled = false;
            }
            else
            {
                AddBttn.IsEnabled = true;
            }
        }

        private void disableRepoBeforeInGroup(object sender, RoutedEventArgs e)
        {
            if (groupCount.Content.Equals(0))
            {
                FileRepBttn.IsEnabled = false;
            }
            else
            {
                FileRepBttn.IsEnabled = true;
            }
        }
    }
}
