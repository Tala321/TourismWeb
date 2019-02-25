namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges172 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "HotelPic", c => c.String(nullable: false));
            AlterColumn("dbo.Hotels", "HotelCountry", c => c.String(nullable: false));
            AlterColumn("dbo.Hotels", "HotelCity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotels", "HotelCity", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Hotels", "HotelCountry", c => c.Boolean(nullable: false));
            DropColumn("dbo.Hotels", "HotelPic");
        }
    }
}
