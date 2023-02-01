namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorks2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Work", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Work", "CustomerId");
        }
    }
}
