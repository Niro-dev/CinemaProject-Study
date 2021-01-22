namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCustomerIdToString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "CustomerUserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "CustomerUserId");
            DropColumn("dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "CustomerUserId");
            AddPrimaryKey("dbo.Customers", "CustomerId");
        }
    }
}
