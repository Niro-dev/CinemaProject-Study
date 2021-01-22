namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTicket1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats");
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "CustomerUserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tickets", "ScreeningDate");
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date");
            DropColumn("dbo.Tickets", "SeatNumber");
            DropColumn("dbo.Tickets", "RowNumber");
            DropColumn("dbo.Tickets", "HallId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "RowNumber", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "SeatNumber", c => c.Short(nullable: false));
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropPrimaryKey("dbo.Tickets");
            DropColumn("dbo.Tickets", "CustomerUserId");
            AddPrimaryKey("dbo.Tickets", new[] { "ScreeningDate", "SeatNumber", "RowNumber", "HallId" });
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "RowNumber", "HallId" }, cascadeDelete: true);
        }
    }
}
