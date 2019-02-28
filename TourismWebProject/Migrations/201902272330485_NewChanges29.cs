namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationServiceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ReservationServiceId");
        }
    }
}
