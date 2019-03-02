namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tours4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tour", "TourStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tour", "TourStatus", c => c.String(nullable: false));
        }
    }
}
