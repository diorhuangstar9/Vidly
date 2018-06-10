namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUnusedMembershipId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "MemeberShipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemeberShipId", c => c.Byte(nullable: false));
        }
    }
}
