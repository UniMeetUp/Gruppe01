﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<bool> Validate_Email_and_Password(UserForLogin userForLogin)
        {
            var str = await _serverAccessLayer.Check_if_Email_and_Password_is_in_database(userForLogin);
            if (str.StatusCode == HttpStatusCode.OK)
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
               var usersInGroups = _serverAccessLayer.Get_DisplayName_In_All_Group_ByEmail(email);

               if (userStr != null && groupStr != null)
               {
                   JObject jsonUser = new JObject(JObject.Parse(userStr.ToString()));
                   JObject.Parse(userStr.ToString());
                   JArray jsonGroup = new JArray(JArray.Parse(groupStr.ToString())); 
                
                   addDisplaynameAndEmailToCurrentUser(jsonUser, user);
                   addGroupsToCurrentuser(jsonGroup, user);
                   addAllMemberDisplayNamesToGroups(usersInGroups, user);
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

            if (user.Groups.Count != 0)
            {
                user.Groups.CurrentGroup = user.Groups[0];
            }
           
        }

        private void addDisplaynameAndEmailToCurrentUser(JObject jsonUser, User user)
        {
            user.DisplayName = jsonUser.GetValue("displayName").ToString();
            user.emailAdresse = jsonUser.GetValue("emailAddress").ToString();
        }



        private void addAllMemberDisplayNamesToGroups(string jsonFromServer, User user)
        {
            var allGroupMemberArray = JsonConvert.DeserializeObject<AllGruopMembersClass[]>(jsonFromServer);

            foreach (var item in allGroupMemberArray)
            {
                for (int i = 0; i < user.Groups.Count; i++)
                {
                    if (item.GroupId == user.Groups[i].GroupId)
                    {
                        for (int j = 0; j < item.UserDisplayNamesList.Count; j++)
                        {
                            user.Groups[i].MemberList.Add(item.UserDisplayNamesList[j].DisplayName);
                        }
                        break;
                    }
                }
            }

            
        }




        private class DisplayNameClass
        {
            public string DisplayName { get; set; }
            
        }

        private class AllGruopMembersClass
        {
            public int GroupId { get; set; }

            public List<DisplayNameClass> UserDisplayNamesList { get; set; } = new List<DisplayNameClass>();
        }


        #endregion
    }
}
