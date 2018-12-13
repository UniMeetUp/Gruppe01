using System.Net;
using System.Windows.Input;
using System.Windows.Media;
using UniMeetUpApplication.Command;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.View;

namespace UniMeetUpApplication.ViewModel
{
    public class ForgotPasswordDialogViewModel : ViewModelBase
    {
        ICommand _sendEmailToUser;
        private static ServerAccessLayer.ServerAccessLayer _sal = new ServerAccessLayer.ServerAccessLayer();

        public ICommand SendEmailToUser
        {
            get
            {
                return _sendEmailToUser ?? (_sendEmailToUser = new RelayCommand<object>((emailTextObject) =>
                {
                    string emailTextAsString = (string)emailTextObject;
                    ForgotPasswordModel _user = new ForgotPasswordModel(emailTextAsString);
                    HttpStatusCode statusCode = _sal.Post_email_to_db(_user);

                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        ForgotPasswordDialog.spinner.Text = "The given email was not found...";
                        ForgotPasswordDialog.spinner.Foreground = Brushes.DarkRed;
                        
                    }
                    else if (statusCode == HttpStatusCode.BadRequest)
                    {
                        ForgotPasswordDialog.spinner.Text = "Error connecting to database, please try again later";
                        ForgotPasswordDialog.spinner.Foreground = Brushes.DarkRed;
                        //MessageBox.Show("Error connecting to database, please try again later");
                    }
                    else if (statusCode == HttpStatusCode.OK)
                    {
                        ForgotPasswordDialog.spinner.Text = "Password was succesfully sent to given mail address";
                        ForgotPasswordDialog.spinner.Foreground = Brushes.Green;
                        //MessageBox.Show("Password was succesfully sent to given mail address");
                    }
                }));
            }
        }
    }
}
