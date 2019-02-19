namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "UserId_UserId" });
            RenameColumn(table: "dbo.ContactForms", name: "UserId_UserId", newName: "User_UserId");
            AddColumn("dbo.ContactForms", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.ContactForms", "User_UserId", c => c.Int());
            CreateIndex("dbo.ContactForms", "User_UserId");
            AddForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactForms", "User_UserId", "dbo.Users");
            DropIndex("dbo.ContactForms", new[] { "User_UserId" });
            AlterColumn("dbo.ContactForms", "User_UserId", c => c.Int(nullable: false));
            DropColumn("dbo.ContactForms", "UserId");
            RenameColumn(table: "dbo.ContactForms", name: "User_UserId", newName: "UserId_UserId");
            CreateIndex("dbo.ContactForms", "UserId_UserId");
            AddForeignKey("dbo.ContactForms", "UserId_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
