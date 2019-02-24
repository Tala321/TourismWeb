namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "BlogItemId", c => c.Int(nullable: true));
            CreateIndex("dbo.Comments", "BlogItemId");
            AddForeignKey("dbo.Comments", "BlogItemId", "dbo.BlogItems", "BlogItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogItemId", "dbo.BlogItems");
            DropIndex("dbo.Comments", new[] { "BlogItemId" });
            DropColumn("dbo.Comments", "BlogItemId");
        }
    }
}
