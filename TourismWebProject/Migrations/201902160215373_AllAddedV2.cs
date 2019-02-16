namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllAddedV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tour", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Tour", new[] { "Room_RoomId" });
            DropColumn("dbo.Tour", "Room_RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "Room_RoomId", c => c.Int());
            CreateIndex("dbo.Tour", "Room_RoomId");
            AddForeignKey("dbo.Tour", "Room_RoomId", "dbo.Rooms", "RoomId");
        }
    }
}
