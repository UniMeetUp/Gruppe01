using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniMeetUpApplication.Command;
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

namespace UniMeetUpApplication.ViewModel
{
    public class MapsViewModel
    {
        
        ICommand _putMarkerCommand;
        public ICommand PutMarkerCommand
        {
            get
            {
                return _putMarkerCommand ?? 
                       (_putMarkerCommand = new RelayCommand(() =>
                       {
                           //WebBrowser.InvokeScript("addMarker", new Object[] { 25.520581, -103.40607);
                           //WebBrowser webBrowser = App.Current.MainWindow.TryFindResource("WebBrowser") as WebBrowser;
                           

                       }));
                
            }
        }
    }
}
