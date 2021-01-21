namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasLimitiationToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "HasAnAgeLimitation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "HasAnAgeLimitation");
        }
    }
}
