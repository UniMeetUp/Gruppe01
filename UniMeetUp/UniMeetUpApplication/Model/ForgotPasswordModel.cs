namespace UniMeetUpApplication.Model
{
    public class ForgotPasswordModel
    {
        public ForgotPasswordModel(string emailAdresse)
        {
            this.EmailAddress = emailAdresse;
        }

        public string EmailAddress { set; get; }
    }
}
