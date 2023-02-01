namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorks3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Work", "EmployerId", "dbo.Employer");
            DropIndex("dbo.Work", new[] { "EmployerId" });
            DropColumn("dbo.Work", "EmployerId");
            DropColumn("dbo.Work", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Work", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Work", "EmployerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Work", "EmployerId");
            AddForeignKey("dbo.Work", "EmployerId", "dbo.Employer", "Id", cascadeDelete: true);
        }
    }
}
