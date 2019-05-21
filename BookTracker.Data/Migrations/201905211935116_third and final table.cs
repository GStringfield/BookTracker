namespace BookTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdandfinaltable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FutureReading",
                c => new
                    {
                        FutureReadingID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.FutureReadingID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FutureReading", "BookID", "dbo.Book");
            DropIndex("dbo.FutureReading", new[] { "BookID" });
            DropTable("dbo.FutureReading");
        }
    }
}
