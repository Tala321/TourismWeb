namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ContactForms", new[] { "User_UserId" });
            DropColumn("dbo.ContactForms", "UserId");
            RenameColumn(table: "dbo.ContactForms", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.ContactForms", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactForms", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContactForms", new[] { "UserId" });
            AlterColumn("dbo.ContactForms", "UserId", c => c.String());
            RenameColumn(table: "dbo.ContactForms", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.ContactForms", "UserId", c => c.String());
            CreateIndex("dbo.ContactForms", "User_UserId");
        }
    }
}
