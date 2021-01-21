namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScreening : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Date)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.HallId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screenings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Screenings", "HallId", "dbo.Halls");
            DropIndex("dbo.Screenings", new[] { "HallId" });
            DropIndex("dbo.Screenings", new[] { "MovieId" });
            DropTable("dbo.Screenings");
        }
    }
}
