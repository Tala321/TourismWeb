namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactPage", "ContactOfficeLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactPage", "ContactOfficeLocation", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
