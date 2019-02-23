namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "AdminPic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPic", c => c.String(nullable: false));
        }
    }
}
