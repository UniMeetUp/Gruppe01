using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

namespace UniMeetUpApplication.Model
{
    public class ChatModel
    {
        IServerAccessLayer _serverAccessLayer = new ServerAccessLayer.ServerAccessLayer();
        public ChatModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public List<MessageForLoad> GetMessagesByGroupId(int groupId)
        {
            var jsonData = _serverAccessLayer.Get_Messages_By_Group_Id(groupId);
            var fetch = JsonConvert.DeserializeObject<MessageForLoad[]>(jsonData);
            return fetch.ToList();
        }
    }
}
