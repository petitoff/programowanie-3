using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CarMechanic.DataAccess;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var ctx = new CarMechanicDbContext())
            {
                return ctx.Customers.AsNoTracking().ToList();
            }
        }
    }
}
