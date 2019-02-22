namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogItems", "BlogItemSource", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.BlogItems", "BlogItemTitle");
            DropColumn("dbo.BlogItems", "BlogItemPic");
            DropColumn("dbo.BlogItems", "BlogItemText");
            DropColumn("dbo.BlogItems", "BlogItemDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogItems", "BlogItemDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BlogItems", "BlogItemText", c => c.String(nullable: false));
            AddColumn("dbo.BlogItems", "BlogItemPic", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.BlogItems", "BlogItemTitle", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.BlogItems", "BlogItemSource");
        }
    }
}
