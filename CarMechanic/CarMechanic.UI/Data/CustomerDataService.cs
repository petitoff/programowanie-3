using System.Collections.Generic;
using System.Linq;
using CarMechanic.DataAccess;
using CarMechanic.Model;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CarMechanic.UI.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly Func<CarMechanicDbContext> _contextCreator;

        public CustomerDataService(Func<CarMechanicDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Customers.AsNoTracking().ToListAsync();
            }
        }
    }
}
