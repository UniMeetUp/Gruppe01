using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommonLib.Models;
using Newtonsoft.Json;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.Model
{
    public class MainMenuModel : IMainMenuModel
    {
        private IServerAccessLayer _serverAccessLayer;
        public MainMenuModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public List<FileMessageForFileFolder> GetAllFilenameAndIdForGroup(int groupId)
        {
            var jsonData = _serverAccessLayer.Get_Group_File_Messages_Name_And_Id(groupId);

            var fetch = JsonConvert.DeserializeObject<FileMessageForFileFolder[]>(jsonData);

            return fetch.ToList();
        }

        public async Task<HttpResponseMessage> CreateGroup(string groupName)
        {
            GroupForCreation group = new GroupForCreation(groupName);
            group.EmailAddress = ((MasterViewModel) App.Current.MainWindow.DataContext).User.emailAdresse;
            var str  = await _serverAccessLayer.Create_Group_in_database(group);

            if (str.StatusCode == HttpStatusCode.Created)
            {
                return str;
            }
            return null;
        }

        public async Task<HttpStatusCode> AddCurrentUserToGroup(string groupName)
        {
            CommonLib.Models.Group group = new CommonLib.Models.Group();
            
            group.GroupName = groupName;
            group.UserGroups.Add(new UserGroup()
            {
                EmailAddress = ((MasterViewModel)App.Current.MainWindow.DataContext).User.emailAdresse,
            });
            
            var str = await _serverAccessLayer.Add_group_with_user(group);

            if (str.StatusCode == HttpStatusCode.Created)
            {
                return str.StatusCode;
            }
            return str.StatusCode;
        }

    }
}
