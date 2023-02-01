using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarMechanic.DataAccess;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public class WorkDataService : IWorkDataService
    {
        private readonly Func<CarMechanicDbContext> _contextCreator;

        public WorkDataService(Func<CarMechanicDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }


        public async Task<List<Work>> GetWorksByEmployerId(int employerId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Works.AsNoTracking().Where(w => w.EmployerId == employerId).ToListAsync();
            }
        }

        public async Task<List<Work>> GetWorksWithCustomerByEmployerId(int employerId)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Works.AsNoTracking().Where(w => w.EmployerId == employerId).Include(w => w.Customer).ToListAsync();
            }
        }

        public async Task AddWorkToEmployerAndCustomer(Work work, int employerId)
        {
            using (var ctx = _contextCreator())
            {
                // find customer by FirstName and LastName and add work to the customer and employer
                var customer = await ctx.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.FirstName == work.Customer.FirstName && c.LastName == work.Customer.LastName);
                if (customer != null)
                {
                    work.CustomerId = customer.Id;
                    work.EmployerId = employerId;
                    ctx.Works.Add(work);
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    // if work.Customer.FirstName and work.Customer.LastName is not in the database, then add work.Customer to the database and then add work to the customer and employer
                    ctx.Customers.Add(work.Customer);
                    await ctx.SaveChangesAsync();
                    work.CustomerId = work.Customer.Id;
                    work.EmployerId = employerId;
                    ctx.Works.Add(work);
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }
}