using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lista_3.Command;
using lista_3.Model;
using lista_3.View;

namespace lista_3.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private AddNewCustomerViewModel _addNewCustomerViewModel;
        private AddCustomerView _addCustomerView;
        public ObservableCollection<Customer> Customers { get; }
        public DelegateCommand AddNewCustomerCommand { get; }

        public CustomersViewModel()
        {
            Customers = new ObservableCollection<Customer>
            {
                new Customer { FirstName = "John", LastName = "Smith" },
                new Customer { FirstName = "Jane", LastName = "Doe"},
                new Customer { FirstName = "Jack", LastName = "Black"}
            };

            AddNewCustomerCommand = new DelegateCommand(AddNewCustomer);
            _addNewCustomerViewModel = new AddNewCustomerViewModel(this);
        }

        private void AddNewCustomer(object obj)
        {
            _addCustomerView = new AddCustomerView
            {
                DataContext = _addNewCustomerViewModel
            };
            _addCustomerView.Show();
        }

        public void GetDataAndCloseAddNewCustomerViewModel(Customer customer)
        {
            Customers.Add(customer);
            _addCustomerView.Close();
        }
    }
}
