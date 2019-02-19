namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "UserId_UserId" });
            AlterColumn("dbo.ContactForms", "UserId_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactForms", "UserId_UserId");
            AddForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "UserId_UserId" });
            AlterColumn("dbo.ContactForms", "UserId_UserId", c => c.Int());
            CreateIndex("dbo.ContactForms", "UserId_UserId");
            AddForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
