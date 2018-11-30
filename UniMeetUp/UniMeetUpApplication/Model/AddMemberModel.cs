using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
       


    }
}
