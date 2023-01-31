namespace CarMechanic.DataAccess.Migrations
{
    using CarMechanic.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarMechanic.DataAccess.CarMechanicDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarMechanic.DataAccess.CarMechanicDbContext context)
        {
            var employer1 = new Employer { FirstName = "John", LastName = "Doe", };
            context.Employers.AddOrUpdate(e => e.FirstName, employer1);

            var customer1 = new Customer { FirstName = "John", LastName = "Smith", EmployerId = employer1.Id };
            context.Customers.AddOrUpdate(c => c.FirstName, customer1);

            context.SaveChanges();
        }
    }
}
