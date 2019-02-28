namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges28 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Reservations");
            DropColumn("dbo.Reservations", "ReservationServiceId");
            AddColumn("dbo.Reservations", "ReservationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Reservations", "ReservationId");
       
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ReservationServiceId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Reservations");
            DropColumn("dbo.Reservations", "ReservationId");
            AddPrimaryKey("dbo.Reservations", "ReservationServiceId");
        }
    }
}
