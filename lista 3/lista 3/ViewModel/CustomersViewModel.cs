using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using lista_3.Command;
using lista_3.Model;
using lista_3.Service;
using lista_3.View;

namespace lista_3.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        // Fields
        private int _numberOfCustomers;
        private bool _isAddCustomerViewVisible;

        // Properties
        public ObservableCollection<Customer> Customers { get; private set; }
        public DelegateCommand AddNewCustomerCommand { get; private set; }
        public DelegateCommand SaveCustomersCommand { get; private set; }
        public DelegateCommand LoadCustomersCommand { get; private set; }
        public AddCustomerView AddCustomerView { get; private set; }
        private AddNewCustomerViewModel AddNewCustomerViewModel { get; set; }

        public int NumberOfCustomers
        {
            get => _numberOfCustomers;
            set
            {
                if (value == _numberOfCustomers) return;
                _numberOfCustomers = value;
                OnPropertyChanged();
            }
        }

        // Constructor
        public CustomersViewModel()
        {
            InitializeCommands();
            InitializeViewModel();
        }

        // Private Helper Methods
        private void InitializeCommands()
        {
            AddNewCustomerCommand = new DelegateCommand(AddNewCustomer);
            SaveCustomersCommand = new DelegateCommand(SaveCustomers);
            LoadCustomersCommand = new DelegateCommand(LoadCustomers);
        }

        private void InitializeViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Customers.CollectionChanged += Customers_CollectionChanged;
            AddNewCustomerViewModel = new AddNewCustomerViewModel(this);
        }

        // Command Methods
        private void AddNewCustomer(object obj)
        {
            if (_isAddCustomerViewVisible) return;

            _isAddCustomerViewVisible = true;
            AddCustomerView = new AddCustomerView { DataContext = AddNewCustomerViewModel };
            AddCustomerView.Show();
        }

        private void SaveCustomers(object? obj)
        {
            var saveFileDialog = CreateSaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                CustomersSerialize.SerializeToXml(Customers, saveFileDialog.FileName);
            }
        }

        private void LoadCustomers(object? obj)
        {
            var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                LoadCustomersFromFile(openFileDialog.FileName);
            }
        }

        private SaveFileDialog CreateSaveFileDialog()
        {
            return new SaveFileDialog
            {
                Title = "Zapisz klientów",
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };
        }

        private OpenFileDialog CreateOpenFileDialog()
        {
            return new OpenFileDialog
            {
                Title = "Wczytaj klientów",
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
            };
        }

        private void LoadCustomersFromFile(string path)
        {
            var newCustomers = CustomersDeserialize.DeserializeFromXml<ObservableCollection<Customer>>(path);
            if (newCustomers == null) return;

            Customers.Clear();
            foreach (var newCustomer in newCustomers)
            {
                Customers.Add(newCustomer);
            }
        }

        // Event Handlers
        private void Customers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NumberOfCustomers = Customers.Count;
        }

        // Public Methods
        public void GetDataAndCloseAddNewCustomerViewModel(Customer customer)
        {
            Customers.Add(customer);
            AddCustomerView.Close();
            _isAddCustomerViewVisible = false;
        }
    }
}
