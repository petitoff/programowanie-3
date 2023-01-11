using System.ComponentModel.DataAnnotations;

namespace CarMechanic.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
