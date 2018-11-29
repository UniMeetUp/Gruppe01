using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Services.ServiceInterfaces
{
    public interface INotificationService
    {
        void Show_Message_Email_Or_Password_Is_Incorrect();
        void Show_Message_Email_Is_Already_In_Use();
        void Show_Message_Emails_Does_Not_Match();
        void Show_Message_Email_Format_Is_Not_Valid();
        void Show_Message_Passwords_Does_Not_Match();
        void Show_Message_Password_Is_Too_Short();
        void Show_Message_Password_Not_Containing_Uppercase_Or_Number();
        void Show_Message_Account_Has_Been_Created();
        void Show_Message_Something_went_wrong();
        void Show_Message_Group_Created();
    }
}

