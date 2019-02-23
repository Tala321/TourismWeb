namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogItems", "BlogItemCover", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogItems", "BlogItemCover");
        }
    }
}
