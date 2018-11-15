using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.Model
{
    public class LoginModel : ILoginModel
    {
        private IServerAccessLayer _serverAccessLayer;
        public LoginModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public bool Validate_Email_and_Password(UserForLogin userForLogin)
        {
            if (_serverAccessLayer.Check_if_Email_and_Password_is_in_database(userForLogin) == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  User getAllUserData()
        {
            

            var str = _serverAccessLayer.Get_all_user_data_from_database();
            
            JObject json = JObject.Parse(str.ToString());


           var user = ((MasterViewModel)App.Current.MainWindow.DataContext).User;

            user.displayName = json.GetValue("displayName").ToString();
            user.emailAdresse = json.GetValue("Email").ToString();

            

            //user.groups = json.GetValue("groups").ToList();

            return user;
        }
    }
}
