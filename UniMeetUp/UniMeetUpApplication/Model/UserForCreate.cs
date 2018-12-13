using System;

namespace UniMeetUpApplication.Model
{
    public class UserForCreate
    {
        public UserForCreate(string email, string password, string displayName)
        {
            Email = email;
            Password = password;
            DisplayName = displayName;
        }

        public String Email { get; set; }
        public String Password { get; set; }
        public String DisplayName { get; set; }
    }
}
