using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace UniMeetUpApplication.ServerAccessLayer
{
    public class ServerAccessLayer : IServerAccessLayer
    {
        private HttpClient client = new HttpClient();

        public ServerAccessLayer()
        {
            client.BaseAddress = new Uri("http://localhost:123");
        }

        public async Task<HttpResponseMessage> Check_if_Email_and_Password_is_in_database(UserForLogin userForLogin)
        {
            //Do something

            HttpResponseMessage response = 
                await client.PostAsJsonAsync("http://localhost:123/", userForLogin);
                
            return response;
        }

        public async Task<string> Get_all_user_data_from_database()
        {
            string str =
                await client.GetStringAsync("");

            return str;
        }

        public void Create_Account_In_Database(UserForCreateAccount userForCreateAccount)
        {
            //Do something
        }

        public bool Check_In_Database_If_Email_Is_Already_In_Use(string username)
        {
            //Do something
            return false;
        }
    }
}
