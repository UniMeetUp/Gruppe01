using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using UniMeetUpApplication.Command;

namespace UniMeetUpApplication.ViewModel
{
    public class ForgotPasswordDialogViewModel : ViewModelBase
    {
        ICommand _sendEmailToUser;
       ServerAccessLayer.ServerAccessLayer _serverAccessLayer = new ServerAccessLayer.ServerAccessLayer();


        public ICommand SendEmailToUser
        {
            get
            {
                return _sendEmailToUser ?? (_sendEmailToUser = new RelayCommand<object>((emailText) =>
                {
                    
                    string to = (string)emailText; //Email'
                    string responseFromServer = _serverAccessLayer.Get_email_from_database(to);


                    if (responseFromServer != "error")
                    {

                        JObject _userInformationJObject = JObject.Parse(responseFromServer);

                        string from = "unimeetupofficial@gmail.com";
                        string subject = "Forgot password, UMU";
                        string body = @"This is an auto-resonse message. This is your current password: " + _userInformationJObject.GetValue("hashedPassword");

                        try
                        {
                            Task mailTask = Task.Factory.StartNew(() =>
                            {
                                MailMessage message = new MailMessage(from, to, subject, body);
                                SmtpClient client = new SmtpClient("mail.stofanet.dk", 587);
                                Console.WriteLine("Changing time out from {0} to 100.", client.Timeout);
                                client.Timeout = 2000;

                                // Credentials are necessary if the server requires the client 
                                // to authenticate before it will send e-mail on the client's behalf.
                                client.Credentials = CredentialCache.DefaultNetworkCredentials;

                               client.Send(message);

                            });

                            mailTask.Wait();

                            MessageBox.Show("Password was sent succesfully.");


                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Email address typed was invalid, please try again");
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                                ex.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("No account with given email, please try again.");
                    }

                    
                }));
            }
        }
    }
}
