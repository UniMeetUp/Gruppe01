using System.Windows.Input;
using UniMeetUpApplication.Command;

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
