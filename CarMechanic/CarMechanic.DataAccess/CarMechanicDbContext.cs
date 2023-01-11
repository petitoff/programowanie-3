using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using CarMechanic.Model;

namespace CarMechanic.DataAccess
{
    public class CarMechanicDbContext : DbContext
    {
        public CarMechanicDbContext() : base("CarMechanicDb")
        {

        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
