namespace CarMechanic.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Work",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.Int(nullable: false),
                        EmployerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employer", t => t.EmployerId, cascadeDelete: true)
                .Index(t => t.EmployerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Work", "EmployerId", "dbo.Employer");
            DropIndex("dbo.Work", new[] { "EmployerId" });
            DropTable("dbo.Work");
        }
    }
}
