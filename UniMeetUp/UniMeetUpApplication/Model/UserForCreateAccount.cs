using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class UserForCreateAccount
    {
        public UserForCreateAccount(string displayName, string email, string password)
        {
            DisplayName = displayName;
            EmailAddress = email;
            HashedPassword = password;
        }

        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
    }
}
