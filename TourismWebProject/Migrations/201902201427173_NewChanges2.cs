namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlogItems", "BlogItemAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogItems", "BlogItemAuthor", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
