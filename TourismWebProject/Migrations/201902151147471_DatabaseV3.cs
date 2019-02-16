namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseV3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Home", newName: "HomePage");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HomePage", newName: "Home");
        }
    }
}
