namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hotels", "HotelStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotels", "HotelStatus", c => c.Boolean(nullable: false));
        }
    }
}
