using System.Collections.ObjectModel;
using System.Linq;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.Event;
using CarMechanic.UI.ViewModel.CustomerServiceViewModel;
using CarMechanic.UI.Window;
using Prism.Events;

namespace CarMechanic.UI.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly IEmployerDataService _employerDataService;
        private string _firstName;
        private string _lastName;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUserDataStore _userDataStore;
        private BaseViewModel _selectedViewModel;

        public CustomersViewModel(IEmployerDataService employerDataService, IEventAggregator eventAggregator,
            IUserDataStore userDataStore, AddCustomerViewModel addCustomerViewModel, EditCustomerViewModel editCustomerViewModel)
        {
            _employerDataService = employerDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateCustomerListEvent>().Subscribe(UpdateCustomerList);
            _userDataStore = userDataStore;

            AddCustomerViewModel = addCustomerViewModel;
            EditCustomerViewModel = editCustomerViewModel;
            SelectedViewModel = AddCustomerViewModel;

            Customers = new ObservableCollection<CustomerItemViewModel>();

            OpenSecondWindowAddCustomerCommand = new DelegateCommand(OpenSecondWindowAddCustomer);
            OpenSecondWindowEditCustomerCommand = new DelegateCommand(OpenSecondWindowEditCustomer);
        }

        private void UpdateCustomerList(Customer obj)
        {
            // create CustomerItemViewModel from Customer
            var customerItemViewModel = new CustomerItemViewModel(obj);

            // add or update customer
            var customer = Customers.SingleOrDefault(c => c.Id == obj.Id);
            if (customer == null)
            {
                Customers.Add(customerItemViewModel);
            }
            else
            {
                customer.FirstName = obj.FirstName;
                customer.LastName = obj.LastName;
            }
        }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
        public AddCustomerViewModel AddCustomerViewModel { get; }
        public EditCustomerViewModel EditCustomerViewModel { get; }
        public ObservableCollection<CustomerItemViewModel> Customers { get; }
        public DelegateCommand OpenSecondWindowAddCustomerCommand { get; }
        public DelegateCommand OpenSecondWindowEditCustomerCommand { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();

            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Execute methods when the ViewModel is loaded
        /// </summary>
        public void Initialize()
        {
            LoadCustomers();
        }

        private void OpenSecondWindowAddCustomer(object obj)
        {
            SelectedViewModel = AddCustomerViewModel;
            OpenSecondWindow();
        }
        
        private void OpenSecondWindowEditCustomer(object obj)
        {
            SelectedViewModel = EditCustomerViewModel;

            if (obj is CustomerItemViewModel customerItemViewModel)
            {
                var customer = new Customer
                {
                    Id = customerItemViewModel.Id,
                    FirstName = customerItemViewModel.FirstName,
                    LastName = customerItemViewModel.LastName
                };

                EditCustomerViewModel.InsertData(customer);
            }

            OpenSecondWindow();
        }

        private void OpenSecondWindow()
        {
            var secondWindow = new SecondWindow
            {
                DataContext = this
            };
            secondWindow.Show();
        }

        #region Data services
        private async void LoadCustomers()
        {
            var customers = await _employerDataService.GetCustomersByEmployerId(_userDataStore.CurrentUserId);
            Customers.Clear();

            //customers.ToList().ForEach(Customers.Add);

            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }
        #endregion
    }
}
