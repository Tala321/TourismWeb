namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges171 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Hotels", "HotelRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "HotelRating", c => c.Int(nullable: false));
        }
    }
}
