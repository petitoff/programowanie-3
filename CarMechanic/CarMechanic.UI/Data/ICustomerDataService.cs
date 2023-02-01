using System.Collections.Generic;
using System.Threading.Tasks;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetAllCustomers();
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task AddCustomerToEmployerById(int employerId, Customer customer);
    }
}