namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hotels", "HotelStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotels", "HotelStatus", c => c.String(nullable: false));
        }
    }
}
