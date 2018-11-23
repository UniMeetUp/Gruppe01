using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

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

    }
}
