namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyModules : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            DropColumn("dbo.Tickets", "HallId");
            RenameColumn(table: "dbo.Tickets", name: "RowNumber", newName: "HallId");
            DropPrimaryKey("dbo.Seats");
            AddColumn("dbo.Seats", "SeatState", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "HallId" });
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "HallId" }, cascadeDelete: true);
            DropColumn("dbo.Seats", "RowNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "RowNumber", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Tickets", new[] { "SeatNumber", "HallId" }, "dbo.Seats");
            DropIndex("dbo.Tickets", new[] { "SeatNumber", "HallId" });
            DropPrimaryKey("dbo.Seats");
            AlterColumn("dbo.Tickets", "HallId", c => c.Byte(nullable: false));
            DropColumn("dbo.Seats", "SeatState");
            AddPrimaryKey("dbo.Seats", new[] { "SeatNumber", "RowNumber", "HallId" });
            RenameColumn(table: "dbo.Tickets", name: "HallId", newName: "RowNumber");
            AddColumn("dbo.Tickets", "HallId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" });
            AddForeignKey("dbo.Tickets", new[] { "SeatNumber", "RowNumber", "HallId" }, "dbo.Seats", new[] { "SeatNumber", "RowNumber", "HallId" }, cascadeDelete: true);
        }
    }
}
