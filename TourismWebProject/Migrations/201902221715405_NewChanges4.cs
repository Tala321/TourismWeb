namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogDetailBlogItems", "BlogDetail_BlogDetailId", "dbo.BlogDetails");
            DropForeignKey("dbo.BlogDetailBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropForeignKey("dbo.TagBlogItems", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropIndex("dbo.BlogDetailBlogItems", new[] { "BlogDetail_BlogDetailId" });
            DropIndex("dbo.BlogDetailBlogItems", new[] { "BlogItem_BlogItemId" });
            DropIndex("dbo.TagBlogItems", new[] { "Tag_TagId" });
            DropIndex("dbo.TagBlogItems", new[] { "BlogItem_BlogItemId" });
            AddColumn("dbo.BlogItems", "DateTime", c => c.DateTime(nullable: false));
            DropTable("dbo.BlogDetails");
            DropTable("dbo.Tags");
            DropTable("dbo.BlogDetailBlogItems");
            DropTable("dbo.TagBlogItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagBlogItems",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.BlogItem_BlogItemId });
            
            CreateTable(
                "dbo.BlogDetailBlogItems",
                c => new
                    {
                        BlogDetail_BlogDetailId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogDetail_BlogDetailId, t.BlogItem_BlogItemId });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.BlogDetails",
                c => new
                    {
                        BlogDetailId = c.Int(nullable: false, identity: true),
                        BlogDetailTitle = c.String(nullable: false, maxLength: 50),
                        BlogDetailText = c.String(nullable: false),
                        BlogDetailPic = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.BlogDetailId);
            
            DropColumn("dbo.BlogItems", "DateTime");
            CreateIndex("dbo.TagBlogItems", "BlogItem_BlogItemId");
            CreateIndex("dbo.TagBlogItems", "Tag_TagId");
            CreateIndex("dbo.BlogDetailBlogItems", "BlogItem_BlogItemId");
            CreateIndex("dbo.BlogDetailBlogItems", "BlogDetail_BlogDetailId");
            AddForeignKey("dbo.TagBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems", "BlogItemId", cascadeDelete: true);
            AddForeignKey("dbo.TagBlogItems", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
            AddForeignKey("dbo.BlogDetailBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems", "BlogItemId", cascadeDelete: true);
            AddForeignKey("dbo.BlogDetailBlogItems", "BlogDetail_BlogDetailId", "dbo.BlogDetails", "BlogDetailId", cascadeDelete: true);
        }
    }
}
