namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Statuses", "StatusName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Statuses", "StatusName", c => c.Boolean(nullable: false));
        }
    }
}
