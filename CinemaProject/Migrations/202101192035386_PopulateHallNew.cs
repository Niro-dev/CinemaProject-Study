namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateHallNew : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Halls ON");

            Sql("INSERT INTO Halls (Id) VALUES (1)");
            Sql("INSERT INTO Halls (Id) VALUES (2)");
            Sql("INSERT INTO Halls (Id) VALUES (3)");
            Sql("INSERT INTO Halls (Id) VALUES (4)");
            Sql("INSERT INTO Halls (Id) VALUES (5)");

            Sql("SET IDENTITY_INSERT Halls OFF");
        }
        
        public override void Down()
        {
        }
    }
}
