using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
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

        // get works by employer id
        //public async Task<List<Work>> GetWorksByEmployerId(int employerId)
        //{
        //    using (var ctx = _contextCreator())
        //    {
        //        return await ctx.Works
        //            .Where(w => w.EmployerId == employerId)
        //            .ToListAsync();
        //    }
        //}
    }
}