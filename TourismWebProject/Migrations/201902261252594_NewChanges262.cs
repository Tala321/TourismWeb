namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges262 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        HotelId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelId, t.RoomId })
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomHotels",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Hotel_HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Hotel_HotelId })
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId, cascadeDelete: true)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Hotel_HotelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.HotelRooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomHotels", new[] { "Hotel_HotelId" });
            DropIndex("dbo.RoomHotels", new[] { "Room_RoomId" });
            DropIndex("dbo.HotelRooms", new[] { "RoomId" });
            DropIndex("dbo.HotelRooms", new[] { "HotelId" });
            DropTable("dbo.RoomHotels");
            DropTable("dbo.HotelRooms");
        }
    }
}
