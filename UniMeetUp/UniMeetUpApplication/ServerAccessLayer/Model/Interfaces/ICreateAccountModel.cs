using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model.Interfaces
{
    public interface ICreateAccountModel
    {
        bool Validate_Email(string email);
        void Create_Account(UserForCreateAccount userForCreateAccount);
    }
}
