using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Command;
using CarMechanic.UI.Data;
using CarMechanic.UI.Window;

namespace CarMechanic.UI.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly IEmployerDataService _employerDataService;
        private string _firstName;
        private string _lastName;

        public CustomersViewModel(IEmployerDataService employerDataService)
        {
            _employerDataService = employerDataService;

            Employers = new ObservableCollection<Employer>();
            OpenSecondWindowCommand = new DelegateCommand(OpenSecondWindow);
            AddCustomerCommand = new DelegateCommand(AddCustomer);
        }


        public ObservableCollection<Employer> Employers { get; set; }
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
            set { _lastName = value; 
                OnPropertyChanged(); }
        }


        /// <summary>
        /// Execute methods when the ViewModel is loaded
        /// </summary>
        public void Initialize()
        {
            LoadEmployers();
        }

        private async void LoadEmployers()
        {
            var employers = await _employerDataService.GetAllEmployers();

            Employers.Clear();

            // add all employers to the collection with linq
            employers.ToList().ForEach(Employers.Add);
        }

        private void OpenSecondWindow(object obj)
        {
            var secondWindow = new SecondWindow();
            secondWindow.DataContext = this;
            secondWindow.Show();



        }

        private void AddCustomer(object obj)
        {
            var customer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName
            };


            //_employerDataService.AddCustomer(customer);
        }
    }
}
