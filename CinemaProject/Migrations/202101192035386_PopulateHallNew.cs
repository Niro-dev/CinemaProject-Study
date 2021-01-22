namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateHallNew : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Halls ON");

            Sql("INSERT INTO Halls (CustomerUserId) VALUES (1)");
            Sql("INSERT INTO Halls (CustomerUserId) VALUES (2)");
            Sql("INSERT INTO Halls (CustomerUserId) VALUES (3)");
            Sql("INSERT INTO Halls (CustomerUserId) VALUES (4)");
            Sql("INSERT INTO Halls (CustomerUserId) VALUES (5)");

            Sql("SET IDENTITY_INSERT Halls OFF");
        }
        
        public override void Down()
        {
        }
    }
}
