namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropForeignKey("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories");
            DropForeignKey("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories");
            DropForeignKey("dbo.BlogDetails", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails");
            DropForeignKey("dbo.BlogItems", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails");
            DropForeignKey("dbo.BlogItems", "BlogTag_BlogTagId", "dbo.BlogTags");
            DropForeignKey("dbo.Tags", "BlogTag_BlogTagId", "dbo.BlogTags");
            DropIndex("dbo.Admins", new[] { "BlogItem_BlogItemId" });
            DropIndex("dbo.BlogCategories", new[] { "BlogItemCategory_BlogItemCategoryId" });
            DropIndex("dbo.BlogDetails", new[] { "BlogItemDetail_BlogItemId" });
            DropIndex("dbo.BlogItems", new[] { "BlogItemCategory_BlogItemCategoryId" });
            DropIndex("dbo.BlogItems", new[] { "BlogItemDetail_BlogItemId" });
            DropIndex("dbo.BlogItems", new[] { "BlogTag_BlogTagId" });
            DropIndex("dbo.Tags", new[] { "BlogTag_BlogTagId" });
            CreateTable(
                "dbo.BlogItemCategories",
                c => new
                    {
                        BlogCategory_BlogItemId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogCategory_BlogItemId, t.BlogItem_BlogItemId })
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategory_BlogItemId, cascadeDelete: true)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_BlogItemId, cascadeDelete: true)
                .Index(t => t.BlogCategory_BlogItemId)
                .Index(t => t.BlogItem_BlogItemId);
            
            CreateTable(
                "dbo.TagBlogItems",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.BlogItem_BlogItemId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_BlogItemId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.BlogItem_BlogItemId);
            
            AddColumn("dbo.BlogItems", "AdminId_AdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogItems", "AdminId_AdminId");
            AddForeignKey("dbo.BlogItems", "AdminId_AdminId", "dbo.Admins", "AdminId", cascadeDelete: true);
            DropColumn("dbo.Admins", "BlogItem_BlogItemId");
            DropColumn("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId");
            DropColumn("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId");
            DropColumn("dbo.BlogItems", "BlogItemDetail_BlogItemId");
            DropColumn("dbo.BlogItems", "BlogTag_BlogTagId");
            DropColumn("dbo.Tags", "BlogTag_BlogTagId");
            DropTable("dbo.BlogDetails");
            DropTable("dbo.BlogItemCategories");
            DropTable("dbo.BlogItemDetails");
            DropTable("dbo.BlogTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        BlogTagId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogTagId);
            
            CreateTable(
                "dbo.BlogItemDetails",
                c => new
                    {
                        BlogItemId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogItemId);
            
            CreateTable(
                "dbo.BlogItemCategories",
                c => new
                    {
                        BlogItemCategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BlogItemCategoryId);
            
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
                .PrimaryKey(t => t.SubBlogItemId);
            
            AddColumn("dbo.Tags", "BlogTag_BlogTagId", c => c.Int());
            AddColumn("dbo.BlogItems", "BlogTag_BlogTagId", c => c.Int());
            AddColumn("dbo.BlogItems", "BlogItemDetail_BlogItemId", c => c.Int());
            AddColumn("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId", c => c.Int());
            AddColumn("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId", c => c.Int());
            AddColumn("dbo.Admins", "BlogItem_BlogItemId", c => c.Int());
            DropForeignKey("dbo.TagBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropForeignKey("dbo.TagBlogItems", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.BlogItemCategories", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropForeignKey("dbo.BlogItemCategories", "BlogCategory_BlogItemId", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogItems", "AdminId_AdminId", "dbo.Admins");
            DropIndex("dbo.TagBlogItems", new[] { "BlogItem_BlogItemId" });
            DropIndex("dbo.TagBlogItems", new[] { "Tag_TagId" });
            DropIndex("dbo.BlogItemCategories", new[] { "BlogItem_BlogItemId" });
            DropIndex("dbo.BlogItemCategories", new[] { "BlogCategory_BlogItemId" });
            DropIndex("dbo.BlogItems", new[] { "AdminId_AdminId" });
            DropColumn("dbo.BlogItems", "AdminId_AdminId");
            DropTable("dbo.TagBlogItems");
            DropTable("dbo.BlogItemCategories");
            CreateIndex("dbo.Tags", "BlogTag_BlogTagId");
            CreateIndex("dbo.BlogItems", "BlogTag_BlogTagId");
            CreateIndex("dbo.BlogItems", "BlogItemDetail_BlogItemId");
            CreateIndex("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId");
            CreateIndex("dbo.BlogDetails", "BlogItemDetail_BlogItemId");
            CreateIndex("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId");
            CreateIndex("dbo.Admins", "BlogItem_BlogItemId");
            AddForeignKey("dbo.Tags", "BlogTag_BlogTagId", "dbo.BlogTags", "BlogTagId");
            AddForeignKey("dbo.BlogItems", "BlogTag_BlogTagId", "dbo.BlogTags", "BlogTagId");
            AddForeignKey("dbo.BlogItems", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails", "BlogItemId");
            AddForeignKey("dbo.BlogDetails", "BlogItemDetail_BlogItemId", "dbo.BlogItemDetails", "BlogItemId");
            AddForeignKey("dbo.BlogItems", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories", "BlogItemCategoryId");
            AddForeignKey("dbo.BlogCategories", "BlogItemCategory_BlogItemCategoryId", "dbo.BlogItemCategories", "BlogItemCategoryId");
            AddForeignKey("dbo.Admins", "BlogItem_BlogItemId", "dbo.BlogItems", "BlogItemId");
        }
    }
}
