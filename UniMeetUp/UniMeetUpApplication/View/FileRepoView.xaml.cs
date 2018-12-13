using System;
using System.Windows.Controls;

namespace UniMeetUpApplication.View
{
    /// <summary>
    /// Interaction logic for FileRepoView.xaml
    /// </summary>
    public partial class FileRepoView : UserControl
    {
        public FileRepoView()
        {
            InitializeComponent();
        }

        private void largerFontByDefault(object sender, EventArgs e)
        {
            FontSize = 12.0;
        }
    }
}
