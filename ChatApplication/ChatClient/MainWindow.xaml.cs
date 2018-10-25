using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using ChatLib;
using Microsoft.Win32;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection connection;
        private const string storageDir = "ReceivedFiles";
        public MainWindow()
        {
            InitializeComponent();
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
        }

        private async void Connect()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    MessageList.Items.Add(newMessage);
                });
            });

            connection.On<FileMessage>("FileMessage", (file) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    MessageList.Items.Add("File received");

                    Directory.CreateDirectory(storageDir);
                    File.WriteAllBytes(Path.Combine(storageDir, file.FileHeaders), file.FileBinary);
                    MessageList.Items.Add(file.FileHeaders);
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
                MessageList.Items.Add("Connection started");
                //ConnectBtn.IsEnabled = false;
                SendBtn.IsEnabled = true;
            }
            catch (Exception exception)
            {
                MessageList.Items.Add(exception.Message);
            }
        }

        private async void SendBtnEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", "anne", MessageTextBox.Text);
                MessageTextBox.Clear();
                MessageTextBox.Focus();
            }
            catch (Exception exception)
            {
                MessageList.Items.Add(exception.Message);
            }
        }

        private async void SendFileBtnEvent(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fullPath = openFileDialog.FileName;
                string fileName = Path.GetFileName(fullPath);
                FileMessage file = new FileMessage()
                {
                    FileBinary = File.ReadAllBytes(fullPath),
                    FileHeaders = fileName
                };
                try
                {
                    await connection.InvokeAsync("FileMessage", file);
                }
                catch (Exception exception)
                {
                    MessageList.Items.Add(exception.Message);
                }
            }
        }
    }
}
