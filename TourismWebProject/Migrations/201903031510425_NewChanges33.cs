namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourLists",
                c => new
                    {
                        TourListId = c.Int(nullable: false, identity: true),
                        TourId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TourListId)
                .ForeignKey("dbo.Tour", t => t.TourId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TourId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.TourLists", "TourId", "dbo.Tour");
            DropIndex("dbo.TourLists", new[] { "UserId" });
            DropIndex("dbo.TourLists", new[] { "TourId" });
            DropTable("dbo.TourLists");
        }
    }
}
