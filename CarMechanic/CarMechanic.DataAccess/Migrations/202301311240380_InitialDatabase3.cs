namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employer", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employer", "LastName", c => c.String(maxLength: 50));
            DropColumn("dbo.Employer", "Login");
            DropColumn("dbo.Employer", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employer", "Password", c => c.String());
            AddColumn("dbo.Employer", "Login", c => c.String());
            AlterColumn("dbo.Employer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employer", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
