namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropPrimaryKey("dbo.Tickets");
            AddColumn("dbo.Tickets", "ScreeningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "SeatNumber", c => c.Short(nullable: false));
            AddColumn("dbo.Tickets", "RowNumber", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "CreationTime", c => c.DateTime());
            AddColumn("dbo.Tickets", "Paid", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Tickets", new[] { "ScreeningDate", "SeatNumber", "RowNumber", "HallId" });
            CreateIndex("dbo.Tickets", "ScreeningDate");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date", cascadeDelete: false);
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "RowNumber", "HallId" }, cascadeDelete: false);
            DropColumn("dbo.Tickets", "MovieId");
            DropColumn("dbo.Tickets", "Date");
            DropColumn("dbo.Tickets", "Time");
            DropColumn("dbo.Tickets", "Seat");
            DropColumn("dbo.Tickets", "Row");
            DropColumn("dbo.Tickets", "Hall");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Hall", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tickets", "Row", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "Seat", c => c.Short(nullable: false));
            AddColumn("dbo.Tickets", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "MovieId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats");
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            DropIndex("dbo.Tickets", new[] { "ScreeningDate" });
            DropPrimaryKey("dbo.Tickets");
            DropColumn("dbo.Tickets", "Paid");
            DropColumn("dbo.Tickets", "CreationTime");
            DropColumn("dbo.Tickets", "HallId");
            DropColumn("dbo.Tickets", "RowNumber");
            DropColumn("dbo.Tickets", "SeatNumber");
            DropColumn("dbo.Tickets", "ScreeningDate");
            AddPrimaryKey("dbo.Tickets", new[] { "CustomerId", "MovieId", "Date", "Time", "Seat", "Row", "Hall" });
            CreateIndex("dbo.Tickets", "MovieId");
            AddForeignKey("dbo.Tickets", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
