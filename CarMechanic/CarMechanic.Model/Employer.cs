using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarMechanic.Model
{
    public class Employer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
