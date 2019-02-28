namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges263 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomHotels", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomHotels", "Hotel_HotelId", "dbo.Hotels");
            DropIndex("dbo.RoomHotels", new[] { "Room_RoomId" });
            DropIndex("dbo.RoomHotels", new[] { "Hotel_HotelId" });
            DropTable("dbo.RoomHotels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoomHotels",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Hotel_HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Hotel_HotelId });
            
            CreateIndex("dbo.RoomHotels", "Hotel_HotelId");
            CreateIndex("dbo.RoomHotels", "Room_RoomId");
            AddForeignKey("dbo.RoomHotels", "Hotel_HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
            AddForeignKey("dbo.RoomHotels", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
    }
}
