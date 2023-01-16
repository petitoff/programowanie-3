using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Data;

namespace CarMechanic.UI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ICustomerDataService _customerDataService;
        private string _nameOfUser;
        private string _roleOfUser;
        private readonly IEmployerDataService _employerDataService;

        public MainViewModel(ICustomerDataService customerDataService, IEmployerDataService employerDataService)
        {
            _customerDataService = customerDataService;
            _employerDataService = employerDataService;
            Customers = new ObservableCollection<Customer>();
            Employers = new ObservableCollection<Employer>();
        }

        public ObservableCollection<Employer> Employers { get; set; }

        public ObservableCollection<Customer> Customers { get; set; }

        public string NameOfUser
        {
            get => _nameOfUser;
            set
            {
                _nameOfUser = value;
                OnPropertyChanged();
            }
        }

        public string RoleOfUser
        {
            get => _roleOfUser;
            set
            {
                _roleOfUser = value;
                OnPropertyChanged();
            }
        }

        public async Task OnLoad()
        {

            var customers = await _customerDataService.GetAllCustomers();
            Customers.Clear();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }

            var employers = await _employerDataService.GetAllEmployers();
            Employers.Clear();
            foreach (var employer in employers)
            {
                Employers.Add(employer);
            }

            NameOfUser = $"{Employers[0].FirstName} {Employers[0].LastName}";
            RoleOfUser = $"{Employers[0].Role}";
        }

    }
}
