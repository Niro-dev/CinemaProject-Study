namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNumberInStockPropertyFromMovies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
        }
    }
}
