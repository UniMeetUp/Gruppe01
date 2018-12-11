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
using CommonLib.Models;
using User = UniMeetUpApplication.Model.User;

namespace UniMeetUpApplication.ServerAccessLayer
{
    public class ServerAccessLayer : IServerAccessLayer
    {
        private HttpClient client = new HttpClient();

        Uri serverUri = new Uri("http://62.107.0.222:5000");
        Uri localUri = new Uri("https://localhost:44364/");


        public ServerAccessLayer()
        {
            // for server
            client.BaseAddress = serverUri;

            // for local test
            //client.BaseAddress = localUri;
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

        public Task<string> Get_All_User_In_The_System()
        {
            // get all Users --> api/Users
            var allUsersTask = client.GetStringAsync($"api/Users");

            return allUsersTask;
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




        public async Task<HttpStatusCode> Create_Account_In_Database(UserForCreateAccount userForCreateAccount)
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

        public HttpStatusCode DummyRequestMustReturnOK()
        {

            HttpStatusCode dummyCode = client.GetAsync("$api/Users/dummy").Result.StatusCode;

            return dummyCode;
        }

        public string Get_Messages_By_Group_Id(int groupId)
        {
            var str = client.GetStringAsync($"api/ChatMessages/Group/{groupId}").Result;
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

        public async Task<HttpResponseMessage> Create_Group_in_database(GroupForCreation group)
        {
            var response = await client.PostAsJsonAsync($"api/Groups/createGroup" ,group);
            var strin = response.Content.ReadAsStringAsync();                                                                                                                                                                   

            return response;
        }
        
        public string Get_DisplayName_In_All_Group_ByEmail(string email)
        {
            try
            {
                var str =
                    client.GetStringAsync($"api/Users/{email}/GetAllMembers").Result;


                return str;
            }
            catch (Exception e)
            {
                return "error";

            }
        }

        public async Task<HttpResponseMessage> Add_member_to_group(AddMemberGroup userGroup)
        {
            var response =  await client.PostAsJsonAsync("api/Groups/createUserGroup", userGroup);

            return response;
        }
    }
}
