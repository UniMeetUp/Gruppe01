using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for ForgotPasswordDialog.xaml
    /// </summary>
    public partial class ForgotPasswordDialog : Window
    {
        //s
        public static TextBlock spinner;
        public ForgotPasswordDialog()
        {
            InitializeComponent();
            spinner = TextBlockToAppear;
        }
    }
}
