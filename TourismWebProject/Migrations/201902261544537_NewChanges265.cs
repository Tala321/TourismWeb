namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges265 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HotelRooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.HotelRooms", "RoomId", "dbo.Rooms");
            DropIndex("dbo.HotelRooms", new[] { "HotelId" });
            DropIndex("dbo.HotelRooms", new[] { "RoomId" });
            DropTable("dbo.HotelRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        AssignRoomId = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AssignRoomId, t.HotelId, t.RoomId });
            
            CreateIndex("dbo.HotelRooms", "RoomId");
            CreateIndex("dbo.HotelRooms", "HotelId");
            AddForeignKey("dbo.HotelRooms", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.HotelRooms", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
        }
    }
}
