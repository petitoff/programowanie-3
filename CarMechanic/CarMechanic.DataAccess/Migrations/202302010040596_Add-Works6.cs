namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorks6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Work", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Work", "CustomerId");
            AddForeignKey("dbo.Work", "CustomerId", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Work", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Work", new[] { "CustomerId" });
            DropColumn("dbo.Work", "CustomerId");
        }
    }
}
