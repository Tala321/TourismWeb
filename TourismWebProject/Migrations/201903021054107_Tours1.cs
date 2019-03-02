namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tours1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tour", "TourPic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tour", "TourPic");
        }
    }
}
