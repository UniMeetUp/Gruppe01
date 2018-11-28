using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniMeetUpApplication.Model.Interfaces;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;

namespace UniMeetUpApplication.Model
{
    
    public class CreateAccountModel : ICreateAccountModel
    {
        private IServerAccessLayer _serverAccessLayer;
        public CreateAccountModel(IServerAccessLayer serverAccessLayer)
        {
            _serverAccessLayer = serverAccessLayer;
        }

        public bool Validate_Email(string email)
        {
            if (!_serverAccessLayer.Check_In_Database_If_Email_Is_Already_In_Use(email))
                return true;

            return false;
        }

        public async Task<bool> Create_Account(UserForCreateAccount userForCreateAccount)
        {
            var str = await _serverAccessLayer.Create_Account_In_Database(userForCreateAccount);
            if (str == HttpStatusCode.Created)
            {
                return true;
            }
            return false;

        }
    }
}
