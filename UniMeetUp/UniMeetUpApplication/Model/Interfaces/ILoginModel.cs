using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface ILoginModel
    {
        bool Validate_Email_and_Password(UserForLogin userForLogin);
        User getAllUserData(string email);
    }
}
