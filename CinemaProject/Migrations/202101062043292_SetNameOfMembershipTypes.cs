namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE CustomerUserId = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE CustomerUserId = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE CustomerUserId = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE CustomerUserId = 4");
        }
        
        public override void Down()
        {
        }
    }
}
