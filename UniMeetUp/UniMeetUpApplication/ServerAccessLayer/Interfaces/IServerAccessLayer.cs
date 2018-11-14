using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Model;

namespace UniMeetUpApplication.ServerAccessLayer.Interfaces
{
    public interface IServerAccessLayer
    {
        Task<HttpResponseMessage> Check_if_Email_and_Password_is_in_database(UserForLogin userForLogin);
        void Create_Account_In_Database(UserForCreateAccount userForCreateAccount);
        bool Check_In_Database_If_Email_Is_Already_In_Use(string username);
        Task<string> Get_all_user_data_from_database();
    }
}
