using System.Collections.Generic;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public interface ICustomerDataService
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}