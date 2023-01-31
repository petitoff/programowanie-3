using System.Collections.Generic;
using System.Threading.Tasks;
using CarMechanic.Model;
using CarMechanic.UI.Data;

namespace CarMechanic.UI.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IEmployerDataService _employerDataService;
        private readonly ICustomerDataService _customerDataService;

        public DashboardViewModel(IEmployerDataService employerDataService, ICustomerDataService customerDataService)
        {
            _employerDataService = employerDataService;
            _customerDataService = customerDataService;
        }

        public List<Employer> Employers { get; set; }
        public List<Customer> Customers { get; set; }

        public async Task OnLoad()
        {
            Employers = await _employerDataService.GetAllEmployers();
            Customers = await _customerDataService.GetAllCustomers();
        }
    }
}
