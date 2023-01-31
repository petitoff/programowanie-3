using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using Prism.Events;

namespace CarMechanic.UI.ViewModel.CustomerItemViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        private readonly Customer _customer;
        private readonly ICustomerDataService _customerDataService;
        private readonly IUserDataStore _userDataStore;
        private readonly IEventAggregator _eventAggregator;

        public AddCustomerViewModel(IEventAggregator eventAggregator,ICustomerDataService customerDataService, IUserDataStore userDataStore)
        {
            _eventAggregator = eventAggregator;
            _customerDataService = customerDataService;
            _userDataStore = userDataStore;
            _customer = new Customer();

            AddCustomerCommand = new DelegateCommand(AddCustomer);
        }

        public DelegateCommand AddCustomerCommand { get; }

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

        private void AddCustomer(object obj)
        {
            _customerDataService.AddCustomerToEmployerById(_userDataStore.CurrentUserId, _customer);
            _eventAggregator.GetEvent<UpdateCustomerListEvent>().Publish(_customer);
        }
    }
}
