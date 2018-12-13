using UniMeetUpApplication.Services.ServiceInterfaces;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public void Show(ViewModelBase vm)
        {
            App.Current.MainWindow.DataContext = vm;
        }
    }
}
