using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            client.BaseAddress = new Uri("https://localhost:44364/");
        }

        public  HttpStatusCode Check_if_Email_and_Password_is_in_database(UserForLogin userForLogin)
        {
            //HttpResponseMessage response = await client.PostAsJsonAsync("api/Users/login", userForLogin); DUER IKKE!!!!!
            var response = client.PostAsJsonAsync("api/Users/login", userForLogin).Result;
            
            return response.StatusCode;
        }

        public string Get_user_from_database(string email)
        {
            var str =
                  client.GetStringAsync($"api/Users/{email}").Result;

            return str;
        }

        public string Get_groups_for_specific_user(string email)
        {
            var str =
                client.GetStringAsync($"api/Groups/{email}/all").Result;

            return str;
        }


        public string Get_User_locations_for_group(int id)
        {
            var str =
                client.GetStringAsync($"api/Locations/{id}/all").Result;

            return str;

        }

        public void Create_Account_In_Database(UserForCreateAccount userForCreateAccount)
        {
           // var str =
           //     client.PostAsJsonAsync($"api/User/", userForCreateAccount );
           
        }

        public bool Check_In_Database_If_Email_Is_Already_In_Use(string email)
        {
            
            
            //Do something
            return false;
        }

        public HttpStatusCode Post_user_location(UserLocation userLocation)
        {
            var str =
                client.PostAsJsonAsync($"api/Locations/{userLocation.UserId}/update" ,userLocation).Result;

            return str.StatusCode;
        }
    }
}
