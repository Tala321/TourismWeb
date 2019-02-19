namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "User_UserId" });
            AlterColumn("dbo.ContactForms", "UserId", c => c.String());
            AlterColumn("dbo.ContactForms", "User_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactForms", "User_UserId");
            AddForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "User_UserId" });
            AlterColumn("dbo.ContactForms", "User_UserId", c => c.Int());
            AlterColumn("dbo.ContactForms", "UserId", c => c.String(nullable: false));
            CreateIndex("dbo.ContactForms", "User_UserId");
            AddForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
