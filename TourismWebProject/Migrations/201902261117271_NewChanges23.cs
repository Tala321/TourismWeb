namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "RoomStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomStatus", c => c.String(nullable: false));
        }
    }
}
