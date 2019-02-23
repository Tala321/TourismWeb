namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogCategoryId", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogCategoryBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropIndex("dbo.BlogCategoryBlogItems", new[] { "BlogCategory_BlogCategoryId" });
            DropIndex("dbo.BlogCategoryBlogItems", new[] { "BlogItem_BlogItemId" });
          //  DropTable("dbo.BlogCategoryBlogItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogCategoryBlogItems",
                c => new
                    {
                        BlogCategory_BlogCategoryId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogCategory_BlogCategoryId, t.BlogItem_BlogItemId });
            
            CreateIndex("dbo.BlogCategoryBlogItems", "BlogItem_BlogItemId");
            CreateIndex("dbo.BlogCategoryBlogItems", "BlogCategory_BlogCategoryId");
            AddForeignKey("dbo.BlogCategoryBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems", "BlogItemId", cascadeDelete: true);
            AddForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogCategoryId", "dbo.BlogCategories", "BlogCategoryId", cascadeDelete: true);
        }
    }
}
