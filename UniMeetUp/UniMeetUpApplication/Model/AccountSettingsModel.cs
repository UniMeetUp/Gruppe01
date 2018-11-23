using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

namespace UniMeetUpApplication.Model
{
    public class AccountSettingsModel : IAccountSettingsModel
    {
        private IServerAccessLayer _serverAccessLayer = new ServerAccessLayer.ServerAccessLayer();

        public async Task<bool> Delete_account(User user)
        {
            var str = await _serverAccessLayer.Delete_user_from_DB(user);

            if (str.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
             return false;
        }
    }
}
