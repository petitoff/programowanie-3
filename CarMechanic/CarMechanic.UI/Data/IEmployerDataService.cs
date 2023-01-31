using System.Collections.Generic;
using System.Threading.Tasks;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public interface IEmployerDataService
    {
        Task<List<Employer>> GetAllEmployers();
        Task<List<Employer>> GetAllEmployersWithRelatedCustomers();
        Task<Employer> GetEmployerWithCustomersByEmployerId(int employerId);
        Task<List<Customer>> GetCustomersByEmployerId(int employerId);
        Task UpdateEmployer(Employer employer);
    }
}