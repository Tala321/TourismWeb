namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChange4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogItemId", "dbo.BlogCategories");
            DropPrimaryKey("dbo.BlogCategories");
            DropColumn("dbo.BlogCategories", "BlogItemId");
         
           
            RenameColumn(table: "dbo.BlogCategoryBlogItems", name: "BlogCategory_BlogItemId", newName: "BlogCategory_BlogCategoryId");
            RenameIndex(table: "dbo.BlogCategoryBlogItems", name: "IX_BlogCategory_BlogItemId", newName: "IX_BlogCategory_BlogCategoryId");

            AddColumn("dbo.BlogCategories", "BlogCategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlogCategories", "BlogCategoryName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.BlogCategories", "BlogItemTitle");
            AddPrimaryKey("dbo.BlogCategories", "BlogCategoryId");
            AddForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogCategoryId", "dbo.BlogCategories", "BlogCategoryId", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogCategories", "BlogItemTitle", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.BlogCategories", "BlogItemId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogCategoryId", "dbo.BlogCategories");
            DropPrimaryKey("dbo.BlogCategories");
            DropColumn("dbo.BlogCategories", "BlogCategoryName");
            DropColumn("dbo.BlogCategories", "BlogCategoryId");
            AddPrimaryKey("dbo.BlogCategories", "BlogItemId");
            RenameIndex(table: "dbo.BlogCategoryBlogItems", name: "IX_BlogCategory_BlogCategoryId", newName: "IX_BlogCategory_BlogItemId");
            RenameColumn(table: "dbo.BlogCategoryBlogItems", name: "BlogCategory_BlogCategoryId", newName: "BlogCategory_BlogItemId");
            AddForeignKey("dbo.BlogCategoryBlogItems", "BlogCategory_BlogItemId", "dbo.BlogCategories", "BlogItemId", cascadeDelete: true);
        }
    }
}
