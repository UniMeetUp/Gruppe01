using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MapsView.xaml
    /// </summary>
    public partial class MapsView : UserControl
    {
        public MapsView()
        {
            InitializeComponent();

            // Load map
            LoadMaps();

        }


        public void LoadMaps()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "ApplicationGoogleMaps.html"))
            {

                Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + "ApplicationGoogleMaps.html");
                
                WebBrowser.Navigate(uri);
            }

        }


        private void WebBrowser_OnLoaded(object sender, RoutedEventArgs e)
        {

            ((WebBrowser)sender).ObjectForScripting = new HtmlInteropInternalTestClass();
        }


    }



    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class HtmlInteropInternalTestClass
    {
        public int GetCurrentGroupID()
        {
            return 42;
        }
    }
}
