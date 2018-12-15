using System.Windows.Controls;

namespace Gazete.Dialogs
{
    public partial class InformationMessageDialog : UserControl
    {
        public InformationMessageDialog(string message)
        {
            InitializeComponent();
            DataContext = message;
        }
    }
}
