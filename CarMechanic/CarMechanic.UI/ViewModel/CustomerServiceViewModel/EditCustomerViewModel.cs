using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;

namespace CarMechanic.UI.ViewModel.CustomerServiceViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private Customer _customer;
        private readonly ICustomerDataService _customerDataService;

        public EditCustomerViewModel(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;

            EditCustomerCommand = new DelegateCommand(EditCustomer);
        }
        public DelegateCommand EditCustomerCommand { get; }

        public string FirstName
        {
            get => _customer.FirstName;
            set
            {
                _customer.FirstName = value;
                OnPropertyChanged();
            }
        }
        
        public string LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                OnPropertyChanged();
            }
        }

        public void InsertData(Customer customer)
        {
            _customer = customer;
        }

        private void EditCustomer(object obj)
        {
            _customerDataService.UpdateCustomer(_customer);
        }
    }
}
