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
            Email = email;
            Password = password;
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
