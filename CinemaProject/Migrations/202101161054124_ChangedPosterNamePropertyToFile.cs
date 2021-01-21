namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPosterNamePropertyToFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "file", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Poster");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Poster", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "file");
        }
    }
}
