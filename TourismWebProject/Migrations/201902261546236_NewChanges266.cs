namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges266 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        AssignRoomId = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AssignRoomId, t.HotelId, t.RoomId })
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.HotelRooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.HotelRooms", new[] { "RoomId" });
            DropIndex("dbo.HotelRooms", new[] { "HotelId" });
            DropTable("dbo.HotelRooms");
        }
    }
}
