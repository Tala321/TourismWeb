namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges121 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "CommentTypeId", "dbo.CommentTypes");
            DropForeignKey("dbo.Comments", "ServiceTypeId", "dbo.ServiceTypes");
            DropIndex("dbo.Comments", new[] { "CommentTypeId" });
            DropIndex("dbo.Comments", new[] { "ServiceTypeId" });
            DropColumn("dbo.Comments", "CommentTypeId");
            DropColumn("dbo.Comments", "ServiceTypeId");
            DropTable("dbo.CommentTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommentTypes",
                c => new
                    {
                        CommentTypeId = c.Int(nullable: false, identity: true),
                        CommentTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CommentTypeId);
            
            AddColumn("dbo.Comments", "ServiceTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "CommentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ServiceTypeId");
            CreateIndex("dbo.Comments", "CommentTypeId");
            AddForeignKey("dbo.Comments", "ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "CommentTypeId", "dbo.CommentTypes", "CommentTypeId", cascadeDelete: true);
        }
    }
}
