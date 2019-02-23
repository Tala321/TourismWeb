namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogItems", "BlogItemAuthor", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogItems", "BlogItemAuthor");
        }
    }
}
