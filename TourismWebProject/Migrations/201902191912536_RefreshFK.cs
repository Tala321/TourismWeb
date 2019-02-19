namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "CommentTypeId_CommentTypeId", "dbo.CommentTypes");
            DropForeignKey("dbo.Comments", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Reservations", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Tour", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Tour", "LocationId_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Tour", "RatingId_RatingId", "dbo.Ratings");
            DropIndex("dbo.Comments", new[] { "CommentTypeId_CommentTypeId" });
            DropIndex("dbo.Comments", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Comments", new[] { "UserId_UserId" });
            DropIndex("dbo.Tour", new[] { "LocationId_LocationId" });
            DropIndex("dbo.Tour", new[] { "RatingId_RatingId" });
            DropIndex("dbo.Tour", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Reservations", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Reservations", new[] { "UserId_UserId" });
            RenameColumn(table: "dbo.BlogItems", name: "AdminId_AdminId", newName: "AdminId");
            RenameColumn(table: "dbo.Comments", name: "UserId_UserId", newName: "UserId");
            RenameColumn(table: "dbo.Reservations", name: "UserId_UserId", newName: "UserId");
            RenameColumn(table: "dbo.Comments", name: "CommentTypeId_CommentTypeId", newName: "CommentTypeId");
            RenameColumn(table: "dbo.Comments", name: "ServiceTypeId_ServiceTypeId", newName: "ServiceTypeId");
            RenameColumn(table: "dbo.Hotels", name: "ServiceTypeId_ServiceTypeId", newName: "ServiceTypeId");
            RenameColumn(table: "dbo.Reservations", name: "ServiceTypeId_ServiceTypeId", newName: "ServiceTypeId");
            RenameColumn(table: "dbo.Tour", name: "ServiceTypeId_ServiceTypeId", newName: "ServiceTypeId");
            RenameColumn(table: "dbo.Hotels", name: "LocationId_LocationId", newName: "LocationId");
            RenameColumn(table: "dbo.Tour", name: "LocationId_LocationId", newName: "LocationId");
            RenameColumn(table: "dbo.Hotels", name: "RatingId_RatingId", newName: "RatingId");
            RenameColumn(table: "dbo.Tour", name: "RatingId_RatingId", newName: "RatingId");
            RenameColumn(table: "dbo.Tour", name: "HotelId_HotelId", newName: "HotelId");
            RenameIndex(table: "dbo.BlogItems", name: "IX_AdminId_AdminId", newName: "IX_AdminId");
            RenameIndex(table: "dbo.Hotels", name: "IX_LocationId_LocationId", newName: "IX_LocationId");
            RenameIndex(table: "dbo.Hotels", name: "IX_RatingId_RatingId", newName: "IX_RatingId");
            RenameIndex(table: "dbo.Hotels", name: "IX_ServiceTypeId_ServiceTypeId", newName: "IX_ServiceTypeId");
            RenameIndex(table: "dbo.Tour", name: "IX_HotelId_HotelId", newName: "IX_HotelId");
            AlterColumn("dbo.Comments", "CommentTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ServiceTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tour", "LocationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tour", "RatingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tour", "ServiceTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "ServiceTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "CommentTypeId");
            CreateIndex("dbo.Comments", "ServiceTypeId");
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Tour", "LocationId");
            CreateIndex("dbo.Tour", "RatingId");
            CreateIndex("dbo.Tour", "ServiceTypeId");
            CreateIndex("dbo.Reservations", "UserId");
            CreateIndex("dbo.Reservations", "ServiceTypeId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "CommentTypeId", "dbo.CommentTypes", "CommentTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Tour", "ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId", cascadeDelete: false);
            AddForeignKey("dbo.Tour", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: false);
            AddForeignKey("dbo.Tour", "RatingId", "dbo.Ratings", "RatingId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tour", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Tour", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Tour", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Reservations", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Comments", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Comments", "CommentTypeId", "dbo.CommentTypes");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Reservations", new[] { "ServiceTypeId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Tour", new[] { "ServiceTypeId" });
            DropIndex("dbo.Tour", new[] { "RatingId" });
            DropIndex("dbo.Tour", new[] { "LocationId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ServiceTypeId" });
            DropIndex("dbo.Comments", new[] { "CommentTypeId" });
            AlterColumn("dbo.Reservations", "UserId", c => c.Int());
            AlterColumn("dbo.Reservations", "ServiceTypeId", c => c.Int());
            AlterColumn("dbo.Tour", "ServiceTypeId", c => c.Int());
            AlterColumn("dbo.Tour", "RatingId", c => c.Int());
            AlterColumn("dbo.Tour", "LocationId", c => c.Int());
            AlterColumn("dbo.Comments", "UserId", c => c.Int());
            AlterColumn("dbo.Comments", "ServiceTypeId", c => c.Int());
            AlterColumn("dbo.Comments", "CommentTypeId", c => c.Int());
            RenameIndex(table: "dbo.Tour", name: "IX_HotelId", newName: "IX_HotelId_HotelId");
            RenameIndex(table: "dbo.Hotels", name: "IX_ServiceTypeId", newName: "IX_ServiceTypeId_ServiceTypeId");
            RenameIndex(table: "dbo.Hotels", name: "IX_RatingId", newName: "IX_RatingId_RatingId");
            RenameIndex(table: "dbo.Hotels", name: "IX_LocationId", newName: "IX_LocationId_LocationId");
            RenameIndex(table: "dbo.BlogItems", name: "IX_AdminId", newName: "IX_AdminId_AdminId");
            RenameColumn(table: "dbo.Tour", name: "HotelId", newName: "HotelId_HotelId");
            RenameColumn(table: "dbo.Tour", name: "RatingId", newName: "RatingId_RatingId");
            RenameColumn(table: "dbo.Hotels", name: "RatingId", newName: "RatingId_RatingId");
            RenameColumn(table: "dbo.Tour", name: "LocationId", newName: "LocationId_LocationId");
            RenameColumn(table: "dbo.Hotels", name: "LocationId", newName: "LocationId_LocationId");
            RenameColumn(table: "dbo.Tour", name: "ServiceTypeId", newName: "ServiceTypeId_ServiceTypeId");
            RenameColumn(table: "dbo.Reservations", name: "ServiceTypeId", newName: "ServiceTypeId_ServiceTypeId");
            RenameColumn(table: "dbo.Hotels", name: "ServiceTypeId", newName: "ServiceTypeId_ServiceTypeId");
            RenameColumn(table: "dbo.Comments", name: "ServiceTypeId", newName: "ServiceTypeId_ServiceTypeId");
            RenameColumn(table: "dbo.Comments", name: "CommentTypeId", newName: "CommentTypeId_CommentTypeId");
            RenameColumn(table: "dbo.Reservations", name: "UserId", newName: "UserId_UserId");
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "UserId_UserId");
            RenameColumn(table: "dbo.BlogItems", name: "AdminId", newName: "AdminId_AdminId");
            CreateIndex("dbo.Reservations", "UserId_UserId");
            CreateIndex("dbo.Reservations", "ServiceTypeId_ServiceTypeId");
            CreateIndex("dbo.Tour", "ServiceTypeId_ServiceTypeId");
            CreateIndex("dbo.Tour", "RatingId_RatingId");
            CreateIndex("dbo.Tour", "LocationId_LocationId");
            CreateIndex("dbo.Comments", "UserId_UserId");
            CreateIndex("dbo.Comments", "ServiceTypeId_ServiceTypeId");
            CreateIndex("dbo.Comments", "CommentTypeId_CommentTypeId");
            AddForeignKey("dbo.Tour", "RatingId_RatingId", "dbo.Ratings", "RatingId");
            AddForeignKey("dbo.Tour", "LocationId_LocationId", "dbo.Locations", "LocationId");
            AddForeignKey("dbo.Tour", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId");
            AddForeignKey("dbo.Reservations", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId");
            AddForeignKey("dbo.Comments", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes", "ServiceTypeId");
            AddForeignKey("dbo.Comments", "CommentTypeId_CommentTypeId", "dbo.CommentTypes", "CommentTypeId");
            AddForeignKey("dbo.Reservations", "UserId_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
