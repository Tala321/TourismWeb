namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Status", c => c.Boolean(nullable: false));
        }
    }
}
