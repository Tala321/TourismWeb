namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newchanges36 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MainMenus", "MainMenuStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainMenus", "MainMenuStatus", c => c.Boolean(nullable: false));
        }
    }
}
