namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogItems", "BlogCategoryId", c => c.Int(nullable: true));
            CreateIndex("dbo.BlogItems", "BlogCategoryId");
            AddForeignKey("dbo.BlogItems", "BlogCategoryId", "dbo.BlogCategories", "BlogCategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogItems", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.BlogItems", new[] { "BlogCategoryId" });
            DropColumn("dbo.BlogItems", "BlogCategoryId");
        }
    }
}
