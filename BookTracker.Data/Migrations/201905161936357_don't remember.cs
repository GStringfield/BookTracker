namespace BookTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dontremember : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookInventory", "IsOwned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookInventory", "IsOwned", c => c.Boolean(nullable: false));
        }
    }
}
