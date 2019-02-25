namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "HotelCover", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotels", "HotelCover");
        }
    }
}
