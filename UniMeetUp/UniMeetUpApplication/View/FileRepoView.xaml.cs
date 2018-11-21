using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UniMeetUpApplication.Model;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for FileRepoView.xaml
    /// </summary>
    public partial class FileRepoView : UserControl
    {
        // Added 17/11
        Files _files = new Files();
        public FileRepoView()
        {
            InitializeComponent();

            /* FOR TESTING PURPOSES, REASONED NO ACTUAL FILES ARE IN DB */
            //_files.Add(new FileMessage("48d2d824dss884f2w8s", "AntonSlimSihm@gmail.com", 100));
            //_files.Add(new FileMessage("48d2d824dss884f2w8s", "randomMail@outlook.dk", 321232223));
            //_files.Add(new FileMessage("223ddw2", "testing'åøøæ@gmail.com", -1));
            //_files.Add(new FileMessage("48d2d824dss884f2w8s", "efvb", 3));
            /* TESTING STOPS HERE */


            // Added 17/11
            // dataGridFileRepo.ItemsSource = _files;

        }

        private void searchGotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBoxFileRep.Text == "Search for file...")
            {
                searchBoxFileRep.Text = "";
                searchBoxFileRep.Foreground = Brushes.Black;

            }
        }

        private void searchLostFocus(object sender, RoutedEventArgs e)
        {
            if (searchBoxFileRep.Text == "")
            {
                searchBoxFileRep.Text = "Search for file...";
                searchBoxFileRep.Foreground = Brushes.LightGray;

            }
        }
    }
}
