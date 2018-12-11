using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        Uri serverUriChat = new Uri("http://62.107.0.222:5000/chatHub");
        Uri localUriChat = new Uri("https://localhost:44364/chatHub");

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
                .WithUrl(serverUriChat)
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
                bool alignRight = message.UserId == _emailAddress;
                Print_To_Chat_RTF(message.UserId + ":", bold: true, alignRight: alignRight);
                Print_To_Chat_RTF(message.Message, bold: false, alignRight: alignRight);
            }

            MessageList.IsEnabled = true;
        }

        private void Print_To_Chat_RTF(string text, bool bold, bool alignRight)
        {
            string rtf = @"{\rtf1\ansi\deff0 {\fonttbl{\f0 Calibri;}} \pard";
            rtf += alignRight ? @"\qr" : @"\ql";
            rtf += @" \fs23 ";
            rtf += bold ? @"\b \line " : "";
            rtf += text;
            rtf += bold ? @"\b0" : "";
            rtf += @"\par";
                   
            MemoryStream stream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(rtf));
            TextRange range = new TextRange(MessageList.Document.ContentEnd, MessageList.Document.ContentEnd);
            range.Load(stream, DataFormats.Rtf);
        }



        private async void Connect()
        {
            connection.On<string, string, string>("ReceiveMessage", (emailAddress, displayname, message) =>
                {
                    this.Dispatcher.Invoke(() => ReceiveMessage(emailAddress, message));
                });

            connection.On<FileMessage>("FileMessage", (file) =>
            {
                this.Dispatcher.Invoke(() => ReceiveFileMessage(file));
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

        private void ReceiveMessage(string emailAddress, string message)
        {
            bool alignRight = emailAddress == _emailAddress;
            Print_To_Chat_RTF(emailAddress + ":", bold: true, alignRight: alignRight);
            Print_To_Chat_RTF(message, bold: false, alignRight: alignRight);

            MessageList.ScrollToEnd();
        }

        private void ReceiveFileMessage(FileMessage file)
        {
            MessageList.AppendText("File received\n");

            Directory.CreateDirectory(storageDir);
            File.WriteAllBytes(System.IO.Path.Combine(storageDir, file.FileHeaders), file.FileBinary);
            MessageList.AppendText((file.FileHeaders));
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
