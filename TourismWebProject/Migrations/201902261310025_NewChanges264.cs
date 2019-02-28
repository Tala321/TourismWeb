namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges264 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HotelRooms");
            AddColumn("dbo.HotelRooms", "AssignRoomId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.HotelRooms", new[] { "AssignRoomId", "HotelId", "RoomId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.HotelRooms");
            DropColumn("dbo.HotelRooms", "AssignRoomId");
            AddPrimaryKey("dbo.HotelRooms", new[] { "HotelId", "RoomId" });
        }
    }
}
