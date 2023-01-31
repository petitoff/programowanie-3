using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.Event;
using Prism.Events;

namespace CarMechanic.UI.ViewModel.CustomerServiceViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private Customer _customer;
        private readonly ICustomerDataService _customerDataService;
        private readonly IEventAggregator _eventAggregator;

        public EditCustomerViewModel(IEventAggregator eventAggregator,ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
            _eventAggregator = eventAggregator;
            _customer = new Customer();

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
            _eventAggregator.GetEvent<UpdateCustomerListEvent>()
                .Publish(_customer);
        }
    }
}
