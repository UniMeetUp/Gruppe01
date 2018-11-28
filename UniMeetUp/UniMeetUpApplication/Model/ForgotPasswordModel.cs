using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class ForgotPasswordModel
    {
        public ForgotPasswordModel(string emailAdresse)
        {
            this.EmailAddress = emailAdresse;
        }

        public string EmailAddress { set; get; }
        //c
        
    }
}
