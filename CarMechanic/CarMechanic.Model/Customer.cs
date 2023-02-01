using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarMechanic.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
