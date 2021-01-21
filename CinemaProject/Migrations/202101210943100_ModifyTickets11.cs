namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTickets11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "Date", "HallId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Tickets", new[] { "Date", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings", new[] { "Date", "HallId" }, cascadeDelete: true);
        }
    }
}
