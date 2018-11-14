using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.Services.ServiceInterfaces
{
    public interface INavigationService
    {
        void Show(ViewModelBase vm);
    }
}
