using lista_3.Command;
using lista_3.Model;

namespace lista_3.ViewModel
{
    public class AddNewCustomerViewModel
    {
        public Customer Customer { get; set; }

        public DelegateCommand AddNewCustomerCommand { get; }
        private readonly CustomersViewModel _customersViewModel;

        public AddNewCustomerViewModel(CustomersViewModel customersViewModel)
        {
            _customersViewModel = customersViewModel;

            Customer = new Customer();
            AddNewCustomerCommand = new DelegateCommand(AddNewCustomer);
        }

        private void AddNewCustomer(object? obj)
        {
            _customersViewModel.GetDataAndCloseAddNewCustomerViewModel(Customer);
        }
    }
}
