namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "MembershipTypeId");
            AddColumn("dbo.Customers", "CustomerUserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Customers", "CustomerUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "CustomerUserId");
            AddPrimaryKey("dbo.Customers", "Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
