using System.Windows.Controls;

namespace Gazete.Dialogs
{
    public partial class WarningMessageDialog : UserControl
    {
        public WarningMessageDialog(string message)
        {
            InitializeComponent();
            DataContext = message;
        }
    }
}
