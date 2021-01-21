namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatNumber = c.Short(nullable: false),
                        RowNumber = c.Byte(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SeatNumber, t.RowNumber, t.HallId })
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropTable("dbo.Seats");
        }
    }
}
