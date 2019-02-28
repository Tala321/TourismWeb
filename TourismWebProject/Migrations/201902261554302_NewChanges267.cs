namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges267 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HotelRooms");
            AddPrimaryKey("dbo.HotelRooms", new[] { "HotelId", "RoomId" });
            DropColumn("dbo.HotelRooms", "AssignRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HotelRooms", "AssignRoomId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.HotelRooms");
            AddPrimaryKey("dbo.HotelRooms", new[] { "AssignRoomId", "HotelId", "RoomId" });
        }
    }
}
