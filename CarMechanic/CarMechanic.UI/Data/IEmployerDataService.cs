using System.Collections.Generic;
using System.Threading.Tasks;
using CarMechanic.Model;

namespace CarMechanic.UI.Data
{
    public interface IEmployerDataService
    {
        Task<List<Employer>> GetAllEmployers();
    }
}