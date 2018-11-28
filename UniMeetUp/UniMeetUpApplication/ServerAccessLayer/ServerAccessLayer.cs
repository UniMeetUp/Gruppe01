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

        public Task<HttpResponseMessage> Check_if_Email_and_Password_is_in_database(UserForLogin userForLogin)
        {
            //HttpResponseMessage response = await client.PostAsJsonAsync("api/Users/login", userForLogin); DUER IKKE!!!!!
            var response = client.PostAsJsonAsync("api/Users/login", userForLogin);

            return response;
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


        public string Get_Group_WayPoints_for_group(int GroupId)
        {
            // GET: api/Waypoints/5


            var repsResult = client.GetAsync($"api/Waypoints/{GroupId}").Result;

            if (repsResult.StatusCode == HttpStatusCode.NotFound)
            {
                return "error";
            }
           
            return client.GetStringAsync($"api/Waypoints/{GroupId}").Result;
         
            
           
        }




        public async Task<HttpResponseMessage> Create_Account_In_Database(UserForCreateAccount userForCreateAccount)
        {
             var str =
                 await client.PostAsJsonAsync($"api/Users/CreateAccount", userForCreateAccount );
            return str.StatusCode;
        }

        public bool Check_In_Database_If_Email_Is_Already_In_Use(string email)
        {


            //Do something
            return false;
        }

        public HttpStatusCode Post_user_location(UserLocation userLocation)
        {
            var str =
                client.PostAsJsonAsync($"api/Locations/{userLocation.UserId}/update", userLocation).Result;


            return str.StatusCode;
        }

        public HttpStatusCode Post_Group_WayPoint(WayPoint gruopWayPoint)
        {
            var str =
                client.PostAsJsonAsync($"api/Waypoints/{gruopWayPoint.GroupId}/update", gruopWayPoint).Result;
            
            return str.StatusCode;
        }

        public string Get_Group_File_Messages_Name_And_Id(int groupId)
        {
            var str = client.GetStringAsync($"api/FileMessages/Group/{groupId}").Result;
            return str;
        }

        public string Get_File_To_Download_By_Id(int fileId)
        {
            var str = client.GetStringAsync($"api/FileMessages/Download/{fileId}").Result;

            return str;
        }

        public async Task<HttpResponseMessage> Delete_user_from_DB(User user)
        {
            var str =
                await client.DeleteAsync($"api/Users/{user.emailAdresse}");

            return str;
        }

        public string Get_email_from_database(string email)
        {
            
            try
            {
                var str =
                    client.GetStringAsync($"api/Users/{email}").Result;


                return str;
            }
            catch (Exception e)
            {
                return "error";

            }
            
        }

        //s
        public HttpStatusCode Post_email_to_db(ForgotPasswordModel forgotPasswordModel)
        {
            var response = client.PostAsJsonAsync($"api/Users/ForgotPassword", forgotPasswordModel).Result;
            return response.StatusCode;
        }
    }
}
