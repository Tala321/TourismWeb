namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogV3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogItems", "BlogDetail_BlogDetailId", "dbo.BlogDetails");
            DropIndex("dbo.BlogItems", new[] { "BlogDetail_BlogDetailId" });
            CreateTable(
                "dbo.BlogDetailBlogItems",
                c => new
                    {
                        BlogDetail_BlogDetailId = c.Int(nullable: false),
                        BlogItem_BlogItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogDetail_BlogDetailId, t.BlogItem_BlogItemId })
                .ForeignKey("dbo.BlogDetails", t => t.BlogDetail_BlogDetailId, cascadeDelete: true)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_BlogItemId, cascadeDelete: true)
                .Index(t => t.BlogDetail_BlogDetailId)
                .Index(t => t.BlogItem_BlogItemId);
            
            DropColumn("dbo.BlogItems", "BlogDetail_BlogDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogItems", "BlogDetail_BlogDetailId", c => c.Int());
            DropForeignKey("dbo.BlogDetailBlogItems", "BlogItem_BlogItemId", "dbo.BlogItems");
            DropForeignKey("dbo.BlogDetailBlogItems", "BlogDetail_BlogDetailId", "dbo.BlogDetails");
            DropIndex("dbo.BlogDetailBlogItems", new[] { "BlogItem_BlogItemId" });
            DropIndex("dbo.BlogDetailBlogItems", new[] { "BlogDetail_BlogDetailId" });
            DropTable("dbo.BlogDetailBlogItems");
            CreateIndex("dbo.BlogItems", "BlogDetail_BlogDetailId");
            AddForeignKey("dbo.BlogItems", "BlogDetail_BlogDetailId", "dbo.BlogDetails", "BlogDetailId");
        }
    }
}
