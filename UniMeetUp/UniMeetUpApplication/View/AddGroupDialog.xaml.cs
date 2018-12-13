using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace UniMeetUpApplication.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddGroupDialog.xaml
    /// </summary>
    public partial class AddGroupDialog : MetroWindow
    {
        public AddGroupDialog()
        {
            InitializeComponent();
        }

        private void ValidateInput(object sender, TextChangedEventArgs e)
        {
            if (txbGroupName.Text == "")
            {
                addBttn.IsEnabled = false;
            }
            else
            {
                addBttn.IsEnabled = true;
            }
        }

        private void Loaded(object sender, RoutedEventArgs e)
        {
            if (txbGroupName.Text == "")
            {
                addBttn.IsEnabled = false;
            }
        }

        private void AddBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
