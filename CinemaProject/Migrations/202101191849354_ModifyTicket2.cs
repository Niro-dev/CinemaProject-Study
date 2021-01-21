namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTicket2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "SeatNumber", c => c.Short(nullable: false));
            AddColumn("dbo.Tickets", "RowNumber", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tickets", new[] { "ScreeningDate", "SeatNumber", "RowNumber", "HallId" });
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "RowNumber", "HallId" }, cascadeDelete: false);
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            DropPrimaryKey("dbo.Tickets");
            DropColumn("dbo.Tickets", "HallId");
            DropColumn("dbo.Tickets", "RowNumber");
            DropColumn("dbo.Tickets", "SeatNumber");
            AddPrimaryKey("dbo.Tickets", "ScreeningDate");
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date");
        }
    }
}
