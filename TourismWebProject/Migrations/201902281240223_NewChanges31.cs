namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HotelRooms", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HotelRooms", "Status", c => c.String(nullable: false));
        }
    }
}
