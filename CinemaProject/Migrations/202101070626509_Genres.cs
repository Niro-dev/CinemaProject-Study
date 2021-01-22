namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (CustomerUserId, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (CustomerUserId, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (CustomerUserId, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (CustomerUserId, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (CustomerUserId, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
