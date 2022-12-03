using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using lista_3.Command;
using lista_3.Model;
using lista_3.Service;
using lista_3.View;
using Microsoft.Win32;

namespace lista_3.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        public AddCustomerView AddCustomerView;
        private int _numberOfCustomers;
        private AddNewCustomerViewModel AddNewCustomerViewModel { get; set; }
        private bool _isAddCustomerViewVisible;

        public CustomersViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Customers.CollectionChanged += Customers_CollectionChanged;

            AddNewCustomerCommand = new DelegateCommand(AddNewCustomer);
            SaveCustomersCommand = new DelegateCommand(SaveCustomers);
            LoadCustomersCommand = new DelegateCommand(LoadCustomers);

            AddNewCustomerViewModel = new AddNewCustomerViewModel(this);
        }

        public ObservableCollection<Customer> Customers { get; }
        public DelegateCommand AddNewCustomerCommand { get; }
        public DelegateCommand SaveCustomersCommand { get; }
        public DelegateCommand LoadCustomersCommand { get; }

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

        public void GetDataAndCloseAddNewCustomerViewModel(Customer customer)
        {
            Customers.Add(customer);
            AddCustomerView.Close();
            _isAddCustomerViewVisible = false;
        }

        private void AddNewCustomer(object obj)
        {
            if (_isAddCustomerViewVisible)
            {
                return;
            }

            _isAddCustomerViewVisible = true;
            AddCustomerView = new AddCustomerView
            {
                DataContext = AddNewCustomerViewModel
            };
            AddCustomerView.Show();
        }

        private void SaveCustomers(object? obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz klientów";
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;
                CustomersSerialize.SerializeToXml(Customers, path);
            }
        }

        private void LoadCustomers(object? obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wczytaj klientów";
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                var newCustomers = CustomersDeserialize.DeserializeFromXml<ObservableCollection<Customer>>(path);
                Customers.Clear();

                if (newCustomers == null) return;
                foreach (var newCustomer in newCustomers)
                {
                    Customers.Add(newCustomer);
                }
            }
        }

        private void Customers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NumberOfCustomers = Customers.Count();
        }
    }
}
