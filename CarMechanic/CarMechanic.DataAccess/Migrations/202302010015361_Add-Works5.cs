namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorks5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Work", "EmployerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Work", "EmployerId");
            AddForeignKey("dbo.Work", "EmployerId", "dbo.Employer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Work", "EmployerId", "dbo.Employer");
            DropIndex("dbo.Work", new[] { "EmployerId" });
            DropColumn("dbo.Work", "EmployerId");
        }
    }
}
