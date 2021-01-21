namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTickets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropColumn("dbo.Tickets", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "CustomerId");
            AddForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
