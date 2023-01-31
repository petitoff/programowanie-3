using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMechanic.DataAccess;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public class EmployerDataService : IEmployerDataService
    {
        private readonly Func<CarMechanicDbContext> _contextCreator;

        public EmployerDataService(Func<CarMechanicDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        
        public async Task<List<Employer>> GetAllEmployers()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Employers.AsNoTracking().ToListAsync();
            }    
        }

        public async Task<Employer> GetEmployerById(int id)
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Employers.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<List<Employer>> GetAllEmployersWithRelatedCustomers()
        {
            using (var context = _contextCreator())
            {
                var employersWithCustomers = await context.Employers
                    .Include(e => e.Customers)
                    .ToListAsync();

                return employersWithCustomers;
            }
        }

        public async Task<Employer> GetEmployerWithCustomersByEmployerId(int employerId)
        {
            using (var context = _contextCreator())
            {
                var employerWithCustomers = await context.Employers
                    .Include(e => e.Customers)
                    .SingleOrDefaultAsync(e => e.Id == employerId);

                return employerWithCustomers;
            }
        }

        public async Task<List<Customer>> GetCustomersByEmployerId(int employerId)
        {
            using (var context = _contextCreator())
            {
                var customers = await context.Customers
                    .Where(c => c.EmployerId == employerId)
                    .ToListAsync();

                return customers;
            }
        }

        public async Task UpdateEmployer(Employer employer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Employers.Attach(employer);
                ctx.Entry(employer).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task AddEmployer(Employer employer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Employers.Add(employer);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployer(Employer employer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Employers.Attach(employer);
                ctx.Employers.Remove(employer);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
