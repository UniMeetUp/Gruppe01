using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniMeetUpApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Window MasterViewModel;
        public MainWindow()
        {
            InitializeComponent();
            MasterViewModel = MasterWindowToResize;


            ServerAccessLayer.ServerAccessLayer serverAccessLayer = new ServerAccessLayer.ServerAccessLayer();


            /*if (serverAccessLayer.DummyRequestMustReturnOK() == HttpStatusCode.OK)
            {
                MessageBox.Show("Server API Connection is wokring");
            }
            else
            {
                MessageBox.Show("Error");
            }
            */


        }

    }
}
