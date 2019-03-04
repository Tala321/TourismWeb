namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newchanges35 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HomePage", "TestimonialText", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HomePage", "TestimonialText", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
