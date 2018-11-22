using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using CommonLib.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using UniMeetUpApplication.ViewModel;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl
    {
        private HubConnection connection;
        private const string storageDir = "ReceivedFiles";

        private string _emailAddress = ((MasterViewModel) App.Current.MainWindow.DataContext).User.emailAdresse;
        private int _groupId;
        public ChatView()
        {
            InitializeComponent();

            _groupId = ((MasterViewModel)App.Current.MainWindow.DataContext).User.Groups.CurrentGroup.GroupId;

            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44364/chatHub")
                .AddMessagePackProtocol()
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            Connect();
            //MessageList.IsEnabled = true;
        }

        private async void Connect()
        {
            connection.On<string, string>("ReceiveMessage", (emailAddress, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    //String that are is displayed in listbox -> should be changed to displayname
                    var newMessage = $"{emailAddress}: {message}\n";
                    MessageList.AppendText(newMessage);
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
                    //var bitmapImage = new BitmapImage();
                    //using (var ms = new MemoryStream(file.FileBinary))
                    //{
                    //    bitmapImage.BeginInit();
                    //    bitmapImage.StreamSource = ms;
                    //    bitmapImage.EndInit();
                    //}
                    //Image img = new Image();
                    //img.Source = bitmapImage;
                    //ChatHistory.Blocks.Add(new BlockUIContainer(img));
                });
            });

            try
            {
                await connection.StartAsync();
                MessageList.AppendText("Connection started\n");
                //ConnectBtn.IsEnabled = false;
                //SendBtn.IsEnabled = true;

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
                    var newMessage = $"{_emailAddress}: Sent {fileName}\n";
                    MessageList.AppendText(newMessage);
                    MessageList.ScrollToEnd();
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
