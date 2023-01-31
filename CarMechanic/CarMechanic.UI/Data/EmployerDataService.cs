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

        public async Task UpdateEmployer(Employer employer)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Employers.Attach(employer);
                ctx.Entry(employer).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
            }
        }
    }
}
