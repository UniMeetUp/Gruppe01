using System;
using System.Windows.Controls;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for AddMemberView.xaml
    /// </summary>
    public partial class AddMemberView : UserControl
    {
        public AddMemberView()
        {
            InitializeComponent();
        }

        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 12.0;
        }
    }
}
