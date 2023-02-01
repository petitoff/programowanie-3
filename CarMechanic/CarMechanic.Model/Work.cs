using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMechanic.Model
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Time { get; set; }
        
        //public int EmployerId { get; set; }
        //public Employer Employer { get; set; }
        
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
    }
}
