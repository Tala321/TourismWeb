namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tours2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tour", "TourCapacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "TourCapacity", c => c.Int(nullable: false));
        }
    }
}
