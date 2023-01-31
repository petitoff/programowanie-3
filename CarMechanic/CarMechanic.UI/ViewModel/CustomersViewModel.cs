﻿using System.Collections.ObjectModel;
using System.Linq;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.ViewModel.CustomerItemViewModel;
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
            _userDataStore = userDataStore;

            AddCustomerViewModel = addCustomerViewModel;
            EditCustomerViewModel = editCustomerViewModel;
            SelectedViewModel = AddCustomerViewModel;

            Customers = new ObservableCollection<Customer>();

            OpenSecondWindowAddCustomerCommand = new DelegateCommand(OpenSecondWindowAddCustomer);
            OpenSecondWindowEditCustomerCommand = new DelegateCommand(OpenSecondWindowEditCustomer);
            
            
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
        public ObservableCollection<Customer> Customers { get; }
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
            EditCustomerViewModel.InsertData(obj as Customer);
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
            customers.ToList().ForEach(Customers.Add);
        }
        #endregion
    }
}
