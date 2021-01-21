namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTicketsNew : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", new[] { "Date", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings", new[] { "Date", "HallId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "Date", "HallId" });
        }
    }
}
