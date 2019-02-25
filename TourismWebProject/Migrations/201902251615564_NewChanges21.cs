namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "HotelCoverPic", c => c.String(nullable: false));
            DropColumn("dbo.Hotels", "HotelCover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "HotelCover", c => c.String(nullable: false));
            DropColumn("dbo.Hotels", "HotelCoverPic");
        }
    }
}
