namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySeat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats");
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropIndex("dbo.Tickets", new[] { "ScreeningDate" });
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            RenameColumn(table: "dbo.Tickets", name: "HallId", newName: "Date");
            DropPrimaryKey("dbo.Seats");
            AddColumn("dbo.Seats", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime());
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "Date" });
            CreateIndex("dbo.Seats", "Date");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "Date" });
            AddForeignKey("dbo.Seats", "Date", "dbo.Screenings", "Date", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "Date" }, "dbo.Seats", new[] { "SeatNumber", "Date" });
            DropColumn("dbo.Seats", "HallId");
            DropColumn("dbo.Tickets", "ScreeningDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ScreeningDate", c => c.DateTime());
            AddColumn("dbo.Seats", "HallId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "Date" }, "dbo.Seats");
            DropForeignKey("dbo.Seats", "Date", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "Date" });
            DropIndex("dbo.Seats", new[] { "Date" });
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Tickets", "Date", c => c.Byte(nullable: false));
            DropColumn("dbo.Seats", "Date");
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "HallId" });
            RenameColumn(table: "dbo.Tickets", name: "Date", newName: "HallId");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            CreateIndex("dbo.Tickets", "ScreeningDate");
            CreateIndex("dbo.Seats", "HallId");
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "HallId" }, cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date");
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
        }
    }
}
