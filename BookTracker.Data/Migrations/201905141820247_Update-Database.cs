namespace BookTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookInventory",
                c => new
                    {
                        BookInventoryID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        IsOwned = c.Boolean(nullable: false),
                        HasRead = c.Boolean(nullable: false),
                        Notes = c.String(),
                        TypeofBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookInventoryID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookInventory", "BookID", "dbo.Book");
            DropIndex("dbo.BookInventory", new[] { "BookID" });
            DropTable("dbo.BookInventory");
        }
    }
}
