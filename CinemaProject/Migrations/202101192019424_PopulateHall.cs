namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateHall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Screenings", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats");
            DropIndex("dbo.Screenings", new[] { "HallId" });
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            DropPrimaryKey("dbo.Halls");
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Halls", "CustomerUserId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Screenings", "HallId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Seats", "HallId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tickets", "HallId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Halls", "CustomerUserId");
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "HallId" });
            CreateIndex("dbo.Screenings", "HallId");
            CreateIndex("dbo.Seats", "HallId");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            AddForeignKey("dbo.Screenings", "HallId", "dbo.Halls", "CustomerUserId", cascadeDelete: true);
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "CustomerUserId", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "HallId" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats");
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Screenings", "HallId", "dbo.Halls");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropIndex("dbo.Screenings", new[] { "HallId" });
            DropPrimaryKey("dbo.Seats");
            DropPrimaryKey("dbo.Halls");
            AlterColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            AlterColumn("dbo.Seats", "HallId", c => c.Int(nullable: false));
            AlterColumn("dbo.Screenings", "HallId", c => c.Int(nullable: false));
            AlterColumn("dbo.Halls", "CustomerUserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "HallId" });
            AddPrimaryKey("dbo.Halls", "CustomerUserId");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            CreateIndex("dbo.Seats", "HallId");
            CreateIndex("dbo.Screenings", "HallId");
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "HallId" }, cascadeDelete: true);
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "CustomerUserId", cascadeDelete: true);
            AddForeignKey("dbo.Screenings", "HallId", "dbo.Halls", "CustomerUserId", cascadeDelete: true);
        }
    }
}
