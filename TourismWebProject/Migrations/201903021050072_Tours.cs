namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tours : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tour", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Tour", new[] { "RatingId" });
            DropColumn("dbo.Tour", "RatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tour", "RatingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tour", "RatingId");
            AddForeignKey("dbo.Tour", "RatingId", "dbo.Ratings", "RatingId", cascadeDelete: true);
        }
    }
}
