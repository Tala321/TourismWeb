namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newchanges34 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HomePage", "FactHeading");
            DropColumn("dbo.HomePage", "FactText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomePage", "FactText", c => c.String(nullable: false, maxLength: 300));
            AddColumn("dbo.HomePage", "FactHeading", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
