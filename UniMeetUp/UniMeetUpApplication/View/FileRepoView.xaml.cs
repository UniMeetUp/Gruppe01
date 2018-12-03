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
        
        public FileRepoView()
        {
            InitializeComponent();

        }

        //private void searchGotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (searchBoxFileRep.Text == "Search for file...")
        //    {
        //        searchBoxFileRep.Text = "";
        //        searchBoxFileRep.Foreground = Brushes.Black;

        //    }
        //}

        //private void searchLostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (searchBoxFileRep.Text == "")
        //    {
        //        searchBoxFileRep.Text = "Search for file...";
        //        searchBoxFileRep.Foreground = Brushes.LightGray;

        //    }
        //}
        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 12.0;
        }
    }
}
