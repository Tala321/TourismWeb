namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Status");
        }
    }
}
