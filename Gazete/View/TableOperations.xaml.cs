using Gazete.Data.Repository;
using Gazete.ViewModel;
using System.Windows;

namespace Gazete.View
{
    public partial class TableOperations : Window
    {
        public TableOperations()
        {
            InitializeComponent();
            DataContext = new TableOperationsViewModel(new MasaRepository(), new MasaTipiRepository());
        }
    }
}
