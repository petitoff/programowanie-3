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

        public async Task<Customer> GetCustomerById(int id)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Customers.AsNoTracking().SingleAsync(c => c.Id == id);
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Customers.Attach(customer);
                ctx.Entry(customer).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task AddCustomer(Customer customer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Customers.Add(customer);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomer(Customer customer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Customers.Attach(customer);
                ctx.Customers.Remove(customer);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task AddCustomerToEmployerById(int employerId, Customer customer)
        {
            using (var ctx = _contextCreator())
            {
                var employer = await ctx.Employers
                    .Include(e => e.Customers)
                    .SingleAsync(e => e.Id == employerId);

                employer.Customers.Add(customer);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
