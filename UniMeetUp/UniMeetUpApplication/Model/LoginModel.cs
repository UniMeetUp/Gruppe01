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

        public  User getAllUserData(string email)
        {
            // making a reference to the masterViewModel user object
            User user = ((MasterViewModel)App.Current.MainWindow.DataContext).User;
            
               var userStr = _serverAccessLayer.Get_user_from_database(email);
               var groupStr = _serverAccessLayer.Get_groups_for_specific_user(email);

               if (userStr != null && groupStr != null)
               {
                   JObject jsonUser = new JObject(JObject.Parse(userStr.ToString()));JObject.Parse(userStr.ToString());
                   JArray jsonGroup = new JArray(JArray.Parse(groupStr.ToString())); 
                
                   addDisplaynameAndEmailToCurrentUser(jsonUser, user);
                   addGroupsToCurrentuser(jsonGroup, user);
               }
            return user;
        }

        #region HelperFunctions

        private void addGroupsToCurrentuser(JArray jsonGroup, User user)
        {
            for (int i = 0; i < jsonGroup.Count; i++)
            {
                user.Groups.Add(new Group(jsonGroup[i].ToObject<JObject>().GetValue("groupName").ToString(),
                    (int)jsonGroup[i].ToObject<JObject>().GetValue("groupId")));
            }

            user.Groups.CurrentGroup = user.Groups[0];
        }

        private void addDisplaynameAndEmailToCurrentUser(JObject jsonUser, User user)
        {
            user.DisplayName = jsonUser.GetValue("displayName").ToString();
            user.emailAdresse = jsonUser.GetValue("emailAddress").ToString();
        }
        #endregion

    }
}
