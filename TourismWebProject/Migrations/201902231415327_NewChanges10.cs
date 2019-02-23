namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogItems", "BlogItemTitle", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogItems", "BlogItemTitle");
        }
    }
}
