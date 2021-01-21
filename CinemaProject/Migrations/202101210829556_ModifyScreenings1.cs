namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyScreenings1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Date", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "Date" });
            DropPrimaryKey("dbo.Screenings");
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "HallId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Screenings", new[] { "Date", "HallId" });
            AddPrimaryKey("dbo.Tickets", new[] { "SeatNumber", "Date", "HallId" });
            CreateIndex("dbo.Tickets", new[] { "Date", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings", new[] { "Date", "HallId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", new[] { "Date", "HallId" }, "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "Date", "HallId" });
            DropPrimaryKey("dbo.Tickets");
            DropPrimaryKey("dbo.Screenings");
            DropColumn("dbo.Tickets", "HallId");
            AddPrimaryKey("dbo.Tickets", new[] { "SeatNumber", "Date" });
            AddPrimaryKey("dbo.Screenings", "Date");
            CreateIndex("dbo.Tickets", "Date");
            AddForeignKey("dbo.Tickets", "Date", "dbo.Screenings", "Date", cascadeDelete: true);
        }
    }
}
