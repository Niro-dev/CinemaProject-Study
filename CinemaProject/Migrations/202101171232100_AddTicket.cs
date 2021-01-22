namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Seat = c.Short(nullable: false),
                        Row = c.Byte(nullable: false),
                        Hall = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.MovieId, t.Date, t.Time, t.Seat, t.Row, t.Hall })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "CustomerUserId", "dbo.Customers");
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropIndex("dbo.Tickets", new[] { "CustomerUserId" });
            DropTable("dbo.Tickets");
        }
    }
}
