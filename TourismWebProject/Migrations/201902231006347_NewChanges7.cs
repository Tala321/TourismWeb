namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogItems", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.BlogItems", new[] { "BlogCategoryId" });
            DropColumn("dbo.BlogItems", "BlogCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogItems", "BlogCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogItems", "BlogCategoryId");
            AddForeignKey("dbo.BlogItems", "BlogCategoryId", "dbo.BlogCategories", "BlogCategoryId", cascadeDelete: true);
        }
    }
}
