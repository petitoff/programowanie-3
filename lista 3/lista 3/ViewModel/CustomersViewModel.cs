using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using lista_3.Command;
using lista_3.Model;
using lista_3.View;

namespace lista_3.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        public readonly AddCustomerView AddCustomerView;
        private int _numberOfCustomers;
        private AddNewCustomerViewModel AddNewCustomerViewModel { get; set; }

        public CustomersViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Customers.CollectionChanged += Customers_CollectionChanged;

            AddNewCustomerCommand = new DelegateCommand(AddNewCustomer);
            AddNewCustomerViewModel = new AddNewCustomerViewModel(this);
            AddCustomerView = new AddCustomerView();

            // for debug
            GetCustomers();
        }

        public ObservableCollection<Customer> Customers { get; }
        public DelegateCommand AddNewCustomerCommand { get; }

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
            AddCustomerView.Visibility = Visibility.Collapsed;
        }

        private void AddNewCustomer(object obj)
        {
            AddCustomerView.DataContext = AddNewCustomerViewModel;
            AddCustomerView.ShowDialog();
        }

        private void GetCustomers()
        {
            Customers.Add(new Customer
            {
                FirstName = "test",
                LastName = "test2"
            });
        }

        private void Customers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NumberOfCustomers = Customers.Count();
        }
    }
}
