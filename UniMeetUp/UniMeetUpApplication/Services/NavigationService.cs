using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
