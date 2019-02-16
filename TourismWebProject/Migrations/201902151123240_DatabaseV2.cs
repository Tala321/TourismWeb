namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutItems",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutHeading = c.String(nullable: false, maxLength: 50),
                        AboutSubHeading = c.String(nullable: false, maxLength: 100),
                        AboutText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.AboutPage",
                c => new
                    {
                        AboutPageId = c.Int(nullable: false, identity: true),
                        AboutPageBackPic = c.String(nullable: false, maxLength: 100),
                        AboutPageBackPicText = c.String(nullable: false, maxLength: 100),
                        AboutPagePic = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutPageId);
            
            CreateTable(
                "dbo.Advantages",
                c => new
                    {
                        AdvantageId = c.Int(nullable: false, identity: true),
                        AdvantageHeading = c.String(nullable: false, maxLength: 50),
                        AdvantageText = c.String(nullable: false, maxLength: 100),
                        AdvantagePic = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AdvantageId);
            
            CreateTable(
                "dbo.ContactPage",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactBackPic = c.String(nullable: false, maxLength: 100),
                        ContactBackPicText = c.String(nullable: false, maxLength: 100),
                        ContactAddress = c.String(nullable: false, maxLength: 150),
                        ContactPhone = c.String(nullable: false, maxLength: 50),
                        ContactEmail = c.String(nullable: false, maxLength: 100),
                        ContactOfficeLocation = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        FactId = c.Int(nullable: false, identity: true),
                        FactName = c.String(nullable: false, maxLength: 50),
                        FactAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FactId);
            
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        FaqId = c.Int(nullable: false, identity: true),
                        FaqQuestion = c.String(nullable: false, maxLength: 200),
                        FaqAnswer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FaqId);
            
            CreateTable(
                "dbo.Home",
                c => new
                    {
                        HomeId = c.Int(nullable: false, identity: true),
                        HomeBackPic = c.String(nullable: false, maxLength: 50),
                        HomeHeading = c.String(nullable: false, maxLength: 50),
                        HomeText = c.String(nullable: false, maxLength: 100),
                        TestimonialHeading = c.String(nullable: false, maxLength: 50),
                        TestimonialText = c.String(nullable: false, maxLength: 250),
                        NewsLetterHeading = c.String(nullable: false, maxLength: 50),
                        NewsLetterText = c.String(nullable: false, maxLength: 250),
                        FactHeading = c.String(nullable: false, maxLength: 250),
                        FactText = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.HomeId);
            
            CreateTable(
                "dbo.MainMenus",
                c => new
                    {
                        MainMenuId = c.Int(nullable: false, identity: true),
                        MainMenuName = c.String(nullable: false, maxLength: 50),
                        MainMenuStatus = c.Boolean(nullable: false),
                        MainMenuOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MainMenuId);
            
            CreateTable(
                "dbo.SocialMediaLinks",
                c => new
                    {
                        SocialMediaLinkId = c.Int(nullable: false, identity: true),
                        SocialMediaLinkName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.SocialMediaLinkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialMediaLinks");
            DropTable("dbo.MainMenus");
            DropTable("dbo.Home");
            DropTable("dbo.Faqs");
            DropTable("dbo.Facts");
            DropTable("dbo.ContactPage");
            DropTable("dbo.Advantages");
            DropTable("dbo.AboutPage");
            DropTable("dbo.AboutItems");
        }
    }
}
