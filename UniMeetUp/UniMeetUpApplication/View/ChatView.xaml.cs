using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Text;
using System.Windows.Documents;
using CommonLib.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using UniMeetUpApplication.Model;
using UniMeetUpApplication.ServerAccessLayer.Interfaces;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.View
{
    public partial class ChatView : UserControl
    {
        private HubConnection connection;
        private const string storageDir = "ReceivedFiles";

        private string _emailAddress = ((MasterViewModel)App.Current.MainWindow.DataContext).User.emailAdresse;
        private int _groupId;

        private ChatModel _chatModel = new ChatModel(new ServerAccessLayer.ServerAccessLayer());
        public ChatView()
        {
            InitializeComponent();
            MessageList.IsEnabled = false;

            _groupId = ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId;

            connection = new HubConnectionBuilder()
                .WithUrl("https://62.107.0.222:5000/chatHub")
                .AddMessagePackProtocol()
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            Connect();

            List<MessageForLoad> loadedMessages = _chatModel.GetMessagesByGroupId(_groupId);

            foreach (var message in loadedMessages)
            {
                if (message.UserId == _emailAddress)
                {
                    string rtf = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\qr \fs23 \b \line " + message.UserId + ":" + @"\b0\par";
                    MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf));
                    TextRange range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);

                    string rtf2 = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\qr \fs23 " + message.Message + @"\par";
                    stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf2));
                    range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
                else
                {
                    string rtf = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\ql \fs23 \b \line  " + message.UserId + ":" + @"\b0\par";
                    MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf));
                    TextRange range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);

                    string rtf2 = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\ql \fs23 " + message.Message + @"\par";
                    stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf2));
                    range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
            }

            MessageList.IsEnabled = true;
        }

        private async void Connect()
        {
            connection.On<string, string>("ReceiveMessage", (emailAddress, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (emailAddress == _emailAddress)
                    {
                        string rtf = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\qr \fs23 \b \line " + emailAddress + ":" + @"\b0\par";
                        MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf));
                        TextRange range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                        range.Load(stream, DataFormats.Rtf);

                        string rtf2 = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\qr \fs23 " + message + @"\par";
                        stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf2));
                        range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                        range.Load(stream, DataFormats.Rtf);
                    }
                    else
                    {
                        string rtf = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\ql \fs23 \b \line  " + emailAddress + ":" + @"\b0\par";
                        MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf));
                        TextRange range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                        range.Load(stream, DataFormats.Rtf);

                        string rtf2 = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard\ql \fs23 " + message + @"\par";
                        stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf2));
                        range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
                        range.Load(stream, DataFormats.Rtf);
                    }


                    MessageList.ScrollToEnd();
                });
            });

            connection.On<FileMessage>("FileMessage", (file) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    MessageList.AppendText("File received\n");

                    Directory.CreateDirectory(storageDir);
                    File.WriteAllBytes(System.IO.Path.Combine(storageDir, file.FileHeaders), file.FileBinary);
                    MessageList.AppendText((file.FileHeaders));
                });
            });

            try
            {
                await connection.StartAsync();
                MessageList.ScrollToEnd();
            }
            catch (Exception exception)
            {
                MessageList.AppendText(exception.Message);
            }

            await connection.InvokeAsync("JoinGroup", _groupId);
        }

        private async void SendBtnEvent(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async Task SendMessage()
        {
            try
            {
                //Calls method in hub - with the three arguments: email, groupid and message
                await connection.InvokeAsync("SendMessage", _emailAddress, _groupId, MessageTextBox.Text);
                MessageTextBox.Clear();
                MessageTextBox.Focus();
            }
            catch (Exception exception)
            {
                MessageList.AppendText(exception.Message);
            }
        }

        private async void SendFileBtnEvent(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fullPath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(fullPath);
                FileMessage file = new FileMessage()
                {
                    FileBinary = File.ReadAllBytes(fullPath),
                    FileHeaders = fileName
                };
                try
                {
                    await connection.InvokeAsync("FileMessage", _emailAddress, _groupId, file);
                    await connection.InvokeAsync("SendMessage", _emailAddress, _groupId, "Sent file \"" + fileName + "\"");
                }
                catch (Exception exception)
                {
                    MessageList.AppendText(exception.Message);
                }
            }
        }

        private void MessageTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && MessageTextBox.Text != "")
            {
                SendMessage();
            }
        }

        // coloring
        private void ColoringGotFocus(object sender, RoutedEventArgs e)
        {
            MessageTextBox.Background = Brushes.AliceBlue;
        }

        private void ColoringLostfocus(object sender, RoutedEventArgs e)
        {
            MessageTextBox.Background = Brushes.White;
        }
    }
}
