namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyScreenings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "Price", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Screenings", "Price");
        }
    }
}
