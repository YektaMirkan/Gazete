using Gazete.Data;
using Gazete.Data.Repository;
using Gazete.Services;
using Gazete.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Gazete.ViewModel
{
    public class TableOperationsViewModel : ViewModelBase
    {
        private Masa _selectedTable;
        public Masa SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                OnPropertyChanged();
                if(value != null)
                    SelectedTableType = TableTypes.SingleOrDefault(x => x.Kod == SelectedTable.MasaTipiKod);
            }
        }

        private MasaTipi _selectedTableType;
        public MasaTipi SelectedTableType
        {
            get { return _selectedTableType; }
            set
            {
                _selectedTableType = value;
                OnPropertyChanged();
                if(value != null)
                    SelectedTable.MasaTipi = value;
            }
        }

        private MasaTipi _tableType;
        public MasaTipi TableType
        {
            get { return _tableType; }
            set { _tableType = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MasaTipi> _tableTypes;
        public ObservableCollection<MasaTipi> TableTypes
        {
            get { return _tableTypes; }
            set { _tableTypes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Masa> _tables;
        public ObservableCollection<Masa> Tables
        {
            get { return _tables; }
            set { _tables = value; OnPropertyChanged(); }
        }

        public MasaTipiRepository TableTypeRepo { get; }
        public MasaRepository TableRepo { get; }
        public ICommand AddTableCommand { get; }
        public ICommand RemoveTableCommand { get; }
        public ICommand UpdateTableCommand { get; }
        public ICommand AddTableTypeCommand { get; }

        public TableOperationsViewModel(MasaRepository tableRepo, MasaTipiRepository tableTypeRepo)
        {
            TableRepo = tableRepo;
            TableTypeRepo = tableTypeRepo;
            UpdateTableList();
            UpdateTableTypeList();
            SelectedTable = new Masa() { AcikKapali = false };
            TableType = new MasaTipi();
            AddTableCommand = new CustomCommand(AddTable, CanAddTable);
            RemoveTableCommand = new CustomCommand(RemoveTable, CanRemoveTable);
            UpdateTableCommand = new CustomCommand(UpdateTable, CanUpdateTable);
            AddTableTypeCommand = new CustomCommand(AddTableType, CanAddTableType);
        }

        #region Commands

        #region Add Command
        private async void AddTable(object obj)
        {
            TableRepo.UndoChanges(Tables.ToList());
            TableTypeRepo.UndoChanges(TableTypes.ToList());
            SelectedTable = TableRepo.Add(new Masa()
            {
                Ad = SelectedTable.Ad,
                MasaTipiKod = SelectedTable.MasaTipiKod,
                AcikKapali = false
            });
            UpdateTableList();
            await DialogOperations.DisplayInformationMessage("Masa Eklendi", "TableDialog");
        }

        private bool CanAddTable(object obj) => SelectedTable != null &&
                                                !string.IsNullOrEmpty(SelectedTable.Ad) &&
                                                SelectedTable.MasaTipiKod != null;
        #endregion

        #region Reomve Command
        private async void RemoveTable(object obj)
        {
            var dialogResult = await DialogOperations.DisplayQuestionDialog("Silmek istediğinize emin misiniz?", "Sil", "TableDialog");
            if (dialogResult)
            {
                TableRepo.Remove(SelectedTable);
                UpdateTableList();
                SelectedTable = Tables.Last();
                await DialogOperations.DisplayInformationMessage("Masa Silindi", "TableDialog");
            }

        }

        private bool CanRemoveTable(object obj) => SelectedTable != null && SelectedTable.Kod != 0;
        #endregion

        #region Update Command
        private async void UpdateTable(object obj)
        {
            TableRepo.SaveChanges();
            UpdateTableList();
            await DialogOperations.DisplayInformationMessage("Masa Güncellendi", "TableDialog");
        }

        private bool CanUpdateTable(object obj) => SelectedTable != null && SelectedTable.Kod != 0;
        #endregion

        #region Add Table Type Command
        private async void AddTableType(object obj)
        {
            TableRepo.UndoChanges(Tables.ToList());
            TableTypeRepo.UndoChanges(TableTypes.ToList());
            TableTypeRepo.Add(TableType);
            UpdateTableTypeList();
            await DialogOperations.DisplayInformationMessage("Masa Tipi Eklendi", "TableDialog");
        }

        private bool CanAddTableType(object obj) => TableType != null && !string.IsNullOrEmpty(TableType.Tur);
        
        #endregion

        #endregion

        private void UpdateTableList() => Tables = TableRepo.Items.ToObservableCollection();
        private void UpdateTableTypeList() => TableTypes = TableTypeRepo.Items.ToObservableCollection();
    }
}
