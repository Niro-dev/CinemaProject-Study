namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTicket3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "ScreeningDate" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "ScreeningDate", c => c.DateTime());
            AlterColumn("dbo.Tickets", "CustomerUserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tickets", "CustomerUserId");
            CreateIndex("dbo.Tickets", "ScreeningDate");
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings");
            DropIndex("dbo.Tickets", new[] { "ScreeningDate" });
            DropPrimaryKey("dbo.Tickets");
            AlterColumn("dbo.Tickets", "CustomerUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "ScreeningDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Tickets", new[] { "ScreeningDate", "SeatNumber", "RowNumber", "HallId" });
            CreateIndex("dbo.Tickets", "ScreeningDate");
            AddForeignKey("dbo.Tickets", "ScreeningDate", "dbo.Screenings", "Date", cascadeDelete: true);
        }
    }
}
