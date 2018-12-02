using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommonLib.Models;
using UniMeetUpApplication.Model;
using User = UniMeetUpApplication.Model.User;


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

        Task<string> Get_All_User_In_The_System();

        string Get_DisplayName_In_All_Group_ByEmail(string email);
        HttpStatusCode Post_user_location(UserLocation userLocation);
        string Get_File_To_Download_By_Id(int fileId);
        //s
        Task<HttpResponseMessage> Delete_user_from_DB(User user);
        Task<HttpResponseMessage> Create_Group_in_database(GroupForCreation group);


        HttpStatusCode DummyRequestMustReturnOK();

        string Get_Messages_By_Group_Id(int groupId);

        Task<HttpResponseMessage> Add_member_to_group(AddMemberGroup userGroup);
    }
}
