using System.Collections.ObjectModel;
using System.Linq;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
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

        public CustomersViewModel(IEmployerDataService employerDataService, IEventAggregator eventAggregator,
            IUserDataStore userDataStore)
        {
            _employerDataService = employerDataService;
            _eventAggregator = eventAggregator;
            _userDataStore = userDataStore;

            Customers = new ObservableCollection<Customer>();
            OpenSecondWindowCommand = new DelegateCommand(OpenSecondWindow);
            AddCustomerCommand = new DelegateCommand(AddCustomer);
        }

        public ObservableCollection<Customer> Customers { get; set; }
        public DelegateCommand OpenSecondWindowCommand { get; set; }
        public DelegateCommand AddCustomerCommand { get; set; }
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

        private void OpenSecondWindow(object obj)
        {
            var secondWindow = new SecondWindow();
            secondWindow.DataContext = this;
            secondWindow.Show();
        }

        #region Data services
        private async void LoadCustomers()
        {
            var customers = await _employerDataService.GetCustomersByEmployerId(_userDataStore.CurrentUserId);
            Customers.Clear();
            customers.ToList().ForEach(Customers.Add);
        }
        #endregion

        #region Button Method
        private void AddCustomer(object obj)
        {

        }
        #endregion
    }
}
