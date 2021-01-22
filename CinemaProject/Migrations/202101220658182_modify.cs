namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CustomerUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "CustomerUserId");
            AddForeignKey("dbo.Tickets", "CustomerUserId", "dbo.Customers", "CustomerUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CustomerUserId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "CustomerUserId" });
            DropColumn("dbo.Tickets", "CustomerUserId");
        }
    }
}
