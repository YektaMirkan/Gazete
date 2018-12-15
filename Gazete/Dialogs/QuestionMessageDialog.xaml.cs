using System.Windows.Controls;

namespace Gazete.Dialogs
{
    public partial class QuestionMessageDialog : UserControl
    {
        public string Title { get; set; }
        public string Message { get; set; }


        public QuestionMessageDialog(string message, string title)
        {
            InitializeComponent();
            Message = message;
            Title = title;
            DataContext = this;
        }
    }
}
