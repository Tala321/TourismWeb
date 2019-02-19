namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedV1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactForms", "UserTypeId_UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.ContactForms", new[] { "UserTypeId_UserTypeId" });
            AddColumn("dbo.ContactForms", "UserId_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactForms", "UserId_UserId");
            AddForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.ContactForms", "UserTypeId_UserTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactForms", "UserTypeId_UserTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "UserId_UserId" });
            DropColumn("dbo.ContactForms", "UserId_UserId");
            CreateIndex("dbo.ContactForms", "UserTypeId_UserTypeId");
            AddForeignKey("dbo.ContactForms", "UserTypeId_UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
        }
    }
}
