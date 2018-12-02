using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UniMeetUpApplication.Services.ServiceInterfaces;

namespace UniMeetUpApplication.Services
{
   
    public class NotificationService : INotificationService
    {
        public NotificationService()
        {
        }

        public void Show_Message_Email_Or_Password_Is_Incorrect()
        {
            MessageBox.Show("The e-mail or password you entered is incorrect.\nPlease try again.");
        }

        public void Show_Message_Email_Is_Already_In_Use()
        {
            MessageBox.Show("Email is already in use, please try again.");
        }

        public void Show_Message_Emails_Does_Not_Match()
        {
            MessageBox.Show("E-mails does not match.");
        }

        public void Show_Message_Email_Format_Is_Not_Valid()
        {
            MessageBox.Show("E-mail format is invalid.");
        }

        public void Show_Message_Passwords_Does_Not_Match()
        {
            MessageBox.Show("Passwords does not match.");
        }

        public void Show_Message_Password_Is_Too_Short()
        {
            MessageBox.Show("Password is too short, must be at least 8 characters.");
        }

        public void Show_Message_Password_Not_Containing_Uppercase_Or_Number()
        {
            MessageBox.Show("Password must contain at least one uppercase letter and one number.");
        }


        public void Show_Message_Account_Has_Been_Created()
        {
            MessageBox.Show("Your account has been successfully created.");
        }
        public void Show_Message_Something_went_wrong()
        {
            MessageBox.Show("Something went wrong");
        }

        public void Show_Message_Group_Created()
        {
            MessageBox.Show("Your group has been successfully created");
        }

        public void Show_Message_Member_was_added_to_group(string email )
        {
            MessageBox.Show(email + " was successfully added to group");
        }

        public void Show_Message_Already_in_group(string email)
        {
            MessageBox.Show(email + " is already in the group");
        }
    }
}
