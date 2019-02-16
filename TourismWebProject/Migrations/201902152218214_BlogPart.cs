namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(nullable: false, maxLength: 50),
                        AdminSurname = c.String(nullable: false, maxLength: 50),
                        AdminEmail = c.String(nullable: false, maxLength: 100),
                        AdminPassword = c.String(nullable: false, maxLength: 100),
                        BlogItem_BlogItemId = c.Int(),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_BlogItemId)
                .Index(t => t.BlogItem_BlogItemId);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        BlogItemId = c.Int(nullable: false, identity: true),
                        BlogItemTitle = c.String(nullable: false, maxLength: 100),
                        BlogItemCategory_BlogItemCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogItemId)
                .ForeignKey("dbo.BlogItemCategories", t => t.BlogItemCategory_BlogItemCategoryId)
                .Index(t => t.BlogItemCategory_BlogItemCategoryId);
            
            CreateTable(
                "dbo.BlogDetails",
                c => new
                    {
                        SubBlogItemId = c.Int(nullable: false, identity: true),
                        SubBlogItemTitle = c.String(nullable: false, maxLength: 50),
                        SubBlogItemText = c.String(nullable: false),
                        SubBlogItemPic = c.String(nullable: false, maxLength: 100),
                        BlogItemDetail_BlogItemId = c.Int(),
                    })
                .PrimaryKey(t => t.SubBlogItemId)
                .ForeignKey("dbo.BlogItemDetails", t => t.BlogItemDetail_BlogItemId)
                .Index(t => t.BlogItemDetail_BlogItemId);
            
            CreateTable(
                "dbo.BlogItems",
                c => new
                    {
                        BlogItemId = c.Int(nullable: false, identity: true),
                        BlogItemTitle = c.String(nullable: false, maxLength: 100),
                        BlogItemPic = c.String(nullable: false, maxLength: 100),
                        BlogItemText = c.String(nullable: false),
                        BlogItemAuthor = c.String(nullable: false, maxLength: 50),
                        BlogItemDate = c.DateTime(nullable: false),
                        BlogItemCategory_BlogItemCategoryId = c.Int(),
                        BlogItemDetail_BlogItemId = c.Int(),
                        BlogTag_BlogTagId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogItemId)
                .ForeignKey("dbo.BlogItemCategories", t => t.BlogItemCategory_BlogItemCategoryId)
                .ForeignKey("dbo.BlogItemDetails", t => t.BlogItemDetail_BlogItemId)
                .ForeignKey("dbo.BlogTags", t => t.BlogTag_BlogTagId)
                .Index(t => t.BlogItemCategory_BlogItemCategoryId)
                .Index(t => t.BlogItemDetail_BlogItemId)
                .Index(t => t.BlogTag_BlogTagId);
            
            CreateTable(
                "dbo.BlogItemCategories",
                c => new
                    {
                        BlogItemCategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogItemCategoryId);
            
            CreateTable(
                "dbo.BlogItemDetails",
                c => new
                    {
                        BlogItemId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogItemId);
            
            CreateTable(
                "dbo.BlogPage",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogtBackPic = c.String(nullable: false, maxLength: 100),
                        BlogBackPicText = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        BlogTagId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogTagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 20),
                        BlogTag_BlogTagId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.BlogTags", t => t.BlogTag_BlogTagId)
                .Index(t => t.BlogTag_BlogTagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "BlogTag_BlogTagId", "dbo.BlogTags");
            DropForeignKey("dbo.BlogItems", "BlogTag_BlogTagId", "dbo.BlogTags");
            DropForeignKey("dbo.BlogItems", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails");
            DropForeignKey("dbo.BlogDetails", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails");
            DropForeignKey("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories");
            DropForeignKey("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories");
            DropForeignKey("dbo.Admins", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropIndex("dbo.Tags", new[] { "BlogTag_BlogTagId" });
            DropIndex("dbo.BlogItems", new[] { "BlogTag_BlogTagId" });
            DropIndex("dbo.BlogItems", new[] { "BlogItemDetail_BlogItemId" });
            DropIndex("dbo.BlogItems", new[] { "BlogItemCategory_BlogItemCategoryId" });
            DropIndex("dbo.BlogDetails", new[] { "BlogItemDetail_BlogItemId" });
            DropIndex("dbo.BlogCategories", new[] { "BlogItemCategory_BlogItemCategoryId" });
            DropIndex("dbo.Admins", new[] { "BlogItem_BlogItemId" });
            DropTable("dbo.Tags");
            DropTable("dbo.BlogTags");
            DropTable("dbo.BlogPage");
            DropTable("dbo.BlogItemDetails");
            DropTable("dbo.BlogItemCategories");
            DropTable("dbo.BlogItems");
            DropTable("dbo.BlogDetails");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Admins");
        }
    }
}
