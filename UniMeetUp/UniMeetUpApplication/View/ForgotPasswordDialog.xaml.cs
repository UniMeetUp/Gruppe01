using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for ForgotPasswordDialog.xaml
    /// </summary>
    public partial class ForgotPasswordDialog : MetroWindow
    {
        public static TextBlock spinner;
        public ForgotPasswordDialog()
        {
            InitializeComponent();
            spinner = TextBlockToAppear;
        }
    }
}
