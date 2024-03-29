﻿using CarMechanic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarMechanic.UI.Data
{
    public interface IWorkDataService
    {
        Task<List<Work>> GetWorksByEmployerId(int employerId);
        Task<List<Work>> GetWorksWithCustomerByEmployerId(int employerId);
        Task AddWorkToEmployerAndCustomer(Work work, int employerId);
    }
}