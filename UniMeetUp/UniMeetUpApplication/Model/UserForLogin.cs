using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class UserForLogin
    {
        public UserForLogin(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public String email { get; set; }
        public String password { get; set; }
    }
}
