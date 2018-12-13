using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

namespace UniMeetUpApplication.Model
{
    public class AddMemberModel
    {
        private IServerAccessLayer _serverAccessLayer;

        public AddMemberModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public async Task<List<string>> AllMemberEmails()
        {
            List<string> listOfEmailsToReturn = new List<string>();

            var result = await _serverAccessLayer.Get_All_User_In_The_System();

            JArray jArray = JArray.Parse(result);

            foreach (var jObject in jArray)
            {
                string currentEmail = (string)jObject.ToObject<JObject>().GetValue("emailAddress");
                listOfEmailsToReturn.Add(currentEmail);
            }

            return listOfEmailsToReturn;  
        }
        public async Task<HttpResponseMessage> AddMemberToGroup(AddMemberGroup userGroup)
        {
            var response = await  _serverAccessLayer.Add_member_to_group(userGroup);
            return response;
        }

        public  string getUser(string email)
        {
            var response =   _serverAccessLayer.Get_user_from_database(email);
            JObject JObject = Newtonsoft.Json.Linq.JObject.Parse(response);
            string displayName = JObject.GetValue("displayName").ToString();
            return displayName;
        }
    }
}
