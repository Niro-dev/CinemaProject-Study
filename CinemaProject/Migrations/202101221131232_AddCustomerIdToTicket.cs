namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CustomerUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "CustomerUserId");
            AddForeignKey("dbo.Tickets", "CustomerUserId", "dbo.Customers", "CustomerUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CustomerUserId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "CustomerUserId" });
            DropColumn("dbo.Tickets", "CustomerUserId");
        }
    }
}
