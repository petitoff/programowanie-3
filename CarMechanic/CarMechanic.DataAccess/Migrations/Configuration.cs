﻿using CarMechanic.Model;

namespace CarMechanic.DataAccess.Migrations
{
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

        protected override void Seed(CarMechanicDbContext context)
        {
            context.Customers.AddOrUpdate(f => f.FirstName,
                new Customer
                {
                    FirstName = "John",
                    LastName = "Loe"
                },
                new Customer { FirstName = "Dock", LastName = "Werk" });

            context.Employers.AddOrUpdate(f => f.FirstName,
                new Employer
                {
                    FirstName = "Andrzej",
                    LastName = "Nosiwąs",
                });
        }
    }
}
