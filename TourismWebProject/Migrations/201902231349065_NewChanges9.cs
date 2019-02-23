namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPic", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminPic");
        }
    }
}
