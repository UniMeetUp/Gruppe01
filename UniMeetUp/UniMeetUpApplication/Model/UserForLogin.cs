using System;

namespace UniMeetUpApplication.Model
{
    public class UserForLogin
    {
        public UserForLogin(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public String Email { get; set; }
        public String Password { get; set; }
    }
}
