namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSeatAndModifyTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "Date", "dbo.Screenings");
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "Date" }, "dbo.Seats");
            DropIndex("dbo.Seats", new[] { "Date" });
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "Date" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Tickets", new[] { "SeatNumber", "Date" });
            CreateIndex("dbo.Tickets", "Date");
            AddForeignKey("dbo.Tickets", "Date", "dbo.Screenings", "Date", cascadeDelete: true);
            DropColumn("dbo.Tickets", "CustomerUserId");
            DropTable("dbo.Seats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatNumber = c.Short(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SeatState = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SeatNumber, t.Date });
            
            AddColumn("dbo.Tickets", "CustomerUserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Tickets", "Date", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "Date" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime());
            AddPrimaryKey("dbo.Tickets", "CustomerUserId");
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "Date" });
            CreateIndex("dbo.Seats", "Date");
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "Date" }, "dbo.Seats", new[] { "SeatNumber", "Date" });
            AddForeignKey("dbo.Seats", "Date", "dbo.Screenings", "Date", cascadeDelete: true);
        }
    }
}
