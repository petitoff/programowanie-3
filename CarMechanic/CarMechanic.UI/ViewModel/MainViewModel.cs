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

        public MainViewModel(ICustomerDataService customerDataService)
        {
            Customers = new ObservableCollection<Customer>();
            _customerDataService = customerDataService;
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public async Task OnLoad()
        {

            var customers = await _customerDataService.GetAllCustomers();
            Customers.Clear();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

    }
}
