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

            modelBuilder.Entity<Employer>()
                .HasMany(e => e.Customers)
                .WithRequired(c => c.Employer)
                .HasForeignKey(c => c.EmployerId);

            //modelBuilder.Entity<Employer>()
            //    .HasMany(e => e.Works)
            //    .WithRequired(w => w.Employer)
            //    .HasForeignKey(w => w.EmployerId);

            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Works)
            //    .WithRequired(w => w.Customer)
            //    .HasForeignKey(w => w.CustomerId);

            

            //modelBuilder.Entity<Work>()
            //    .HasRequired(w => w.Customer)
            //    .WithMany(c => c.Works)
            //    .HasForeignKey(w => w.CustomerId);

        }
    }
}