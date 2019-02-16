namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        ContactFormId = c.Int(nullable: false, identity: true),
                        ContactFormName = c.String(nullable: false, maxLength: 60),
                        ContactFormEmail = c.String(nullable: false, maxLength: 100),
                        ContactFormSubject = c.String(nullable: false, maxLength: 100),
                        ContactFormMessage = c.String(nullable: false),
                        UserTypeId_UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactFormId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId_UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId_UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactForms", "UserTypeId_UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.ContactForms", new[] { "UserTypeId_UserTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.ContactForms");
        }
    }
}
