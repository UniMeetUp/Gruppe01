using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Model;


namespace UniMeetUpApplication.ServerAccessLayer.Interfaces
{
    public interface IServerAccessLayer
    {
        Task<HttpResponseMessage> Check_if_Email_and_Password_is_in_database(UserForLogin userForLogin);
        Task<HttpStatusCode> Create_Account_In_Database(UserForCreateAccount userForCreateAccount);
        bool Check_In_Database_If_Email_Is_Already_In_Use(string username);
        string Get_user_from_database(string email);
        string Get_groups_for_specific_user(string email);
        string Get_Group_File_Messages_Name_And_Id(int groupId);
        string Get_User_locations_for_group(int id);

        HttpStatusCode Post_user_location(UserLocation userLocation);
        string Get_File_To_Download_By_Id(int fileId);
        //s
        Task<HttpResponseMessage> Delete_user_from_DB(User user);
    }
}
