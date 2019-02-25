namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges161 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Tour", "LocationId", "dbo.Locations");
            DropIndex("dbo.Hotels", new[] { "LocationId" });
            DropIndex("dbo.Tour", new[] { "LocationId" });
            AddColumn("dbo.Hotels", "HotelCountry", c => c.Boolean(nullable: true));
            AddColumn("dbo.Hotels", "HotelCity", c => c.Boolean(nullable: true));
            DropColumn("dbo.Hotels", "LocationId");
            DropColumn("dbo.Tour", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Hotels", "LocationId", c => c.Int(nullable: false));
            DropColumn("dbo.Hotels", "HotelCity");
            DropColumn("dbo.Hotels", "HotelCountry");
            CreateIndex("dbo.Tour", "LocationId");
            CreateIndex("dbo.Hotels", "LocationId");
            AddForeignKey("dbo.Tour", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Hotels", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
    }
}
