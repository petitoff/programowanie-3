using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;
using CarMechanic.Model;

namespace CarMechanic.DataAccess
{
    public class CarMechanicDbContext : DbContext
    {
        public CarMechanicDbContext() : base("CarMechanicNewDb")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Employer)
                .WithMany(e => e.Customers)
                .HasForeignKey(c => c.EmployerId);

            // work and Employer
            modelBuilder.Entity<Work>()
                .HasRequired(w => w.Employer)
                .WithMany(e => e.Works)
                .HasForeignKey(w => w.EmployerId);

            modelBuilder.Entity<Work>()
                .HasRequired(w => w.Customer)
                .WithMany(c => c.Works)
                .HasForeignKey(w => w.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}