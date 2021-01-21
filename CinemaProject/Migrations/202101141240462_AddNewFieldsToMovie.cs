namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldsToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Plot", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Movies", "Poster", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Poster");
            DropColumn("dbo.Movies", "Plot");
        }
    }
}
