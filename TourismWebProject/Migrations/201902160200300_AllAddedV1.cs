namespace TourismWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllAddedV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false, maxLength: 50),
                        HotelAddress = c.String(nullable: false, maxLength: 100),
                        HotelRating = c.Int(nullable: false),
                        HotelDescription = c.String(nullable: false),
                        HotelStatus = c.Boolean(nullable: false),
                        LocationId_LocationId = c.Int(nullable: false),
                        RatingId_RatingId = c.Int(nullable: false),
                        ServiceTypeId_ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.Locations", t => t.LocationId_LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.RatingId_RatingId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId_ServiceTypeId, cascadeDelete: true)
                .Index(t => t.LocationId_LocationId)
                .Index(t => t.RatingId_RatingId)
                .Index(t => t.ServiceTypeId_ServiceTypeId);
            
            CreateTable(
                "dbo.HotelPhotos",
                c => new
                    {
                        HotelPhotoId = c.Int(nullable: false, identity: true),
                        HotePhotolName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.HotelPhotoId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationCountryName = c.String(nullable: false, maxLength: 50),
                        LocationCityName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LocationId);

            CreateTable(
                "dbo.Tour",
                c => new
                {
                    TourId = c.Int(nullable: false, identity: true),
                    TourName = c.String(nullable: false, maxLength: 50),
                    TourPrice = c.Int(nullable: false),
                    DateFrom = c.DateTime(nullable: false),
                    DateTo = c.DateTime(nullable: false),
                    TourDescription = c.String(nullable: false),
                    TourCapacity = c.Int(nullable: false),
                    TourStatus = c.Boolean(nullable: false),
                    HotelId_HotelId = c.Int(nullable: false),
                    LocationId_LocationId = c.Int(),
                    RatingId_RatingId = c.Int(),
                    ServiceTypeId_ServiceTypeId = c.Int(),

                })
                .PrimaryKey(t => t.TourId)
                .ForeignKey("dbo.Hotels", t => t.HotelId_HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId_LocationId)
                .ForeignKey("dbo.Ratings", t => t.RatingId_RatingId)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId_ServiceTypeId)

                .Index(t => t.HotelId_HotelId)
                .Index(t => t.LocationId_LocationId)
                .Index(t => t.RatingId_RatingId)
                .Index(t => t.ServiceTypeId_ServiceTypeId);
               
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingStar = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RatingId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        ServiceTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                        CommentTypeId_CommentTypeId = c.Int(),
                        ServiceTypeId_ServiceTypeId = c.Int(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.CommentTypes", t => t.CommentTypeId_CommentTypeId)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId_ServiceTypeId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.CommentTypeId_CommentTypeId)
                .Index(t => t.ServiceTypeId_ServiceTypeId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.CommentTypes",
                c => new
                    {
                        CommentTypeId = c.Int(nullable: false, identity: true),
                        CommentTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CommentTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        UserSurname = c.String(nullable: false, maxLength: 50),
                        UserPic = c.String(maxLength: 100),
                        UserPhone = c.String(maxLength: 50),
                        UserEmail = c.String(nullable: false, maxLength: 100),
                        UserInfo = c.String(maxLength: 300),
                        UserCountry = c.String(nullable: false, maxLength: 100),
                        UserPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationServiceId = c.Int(nullable: false, identity: true),
                        ReservationServiceTypeId = c.Int(nullable: false),
                        ReservationDateFrom = c.DateTime(nullable: false),
                        ReservationDateTo = c.DateTime(nullable: false),
                        ReservationTotal = c.Int(nullable: false),
                        ReservationStatus = c.Boolean(nullable: false),
                        ServiceTypeId_ServiceTypeId = c.Int(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationServiceId)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId_ServiceTypeId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.ServiceTypeId_ServiceTypeId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.TourPhotos",
                c => new
                    {
                        TourPhotoId = c.Int(nullable: false, identity: true),
                        TourPhotoName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TourPhotoId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 50),
                        RoomPrice = c.Int(nullable: false),
                        RoomCapacity = c.Int(nullable: false),
                        RoomPic = c.String(nullable: false, maxLength: 50),
                        RoomDescription = c.String(nullable: false),
                        RoomStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.HotelPage",
                c => new
                    {
                        HotelPageId = c.Int(nullable: false, identity: true),
                        HotelPageBackPic = c.String(nullable: false, maxLength: 100),
                        HotelPageBackPicText = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.HotelPageId);
            
            CreateTable(
                "dbo.TourPage",
                c => new
                    {
                        ToursPageId = c.Int(nullable: false, identity: true),
                        ToursPageBackPic = c.String(nullable: false, maxLength: 100),
                        ToursPageBackPicText = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ToursPageId);
            
            CreateTable(
                "dbo.HotelPhotoHotels",
                c => new
                    {
                        HotelPhoto_HotelPhotoId = c.Int(nullable: false),
                        Hotel_HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HotelPhoto_HotelPhotoId, t.Hotel_HotelId })
                .ForeignKey("dbo.HotelPhotos", t => t.HotelPhoto_HotelPhotoId, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId, cascadeDelete: true)
                .Index(t => t.HotelPhoto_HotelPhotoId)
                .Index(t => t.Hotel_HotelId);
            
            CreateTable(
                "dbo.TourPhotoTours",
                c => new
                    {
                        TourPhoto_TourPhotoId = c.Int(nullable: false),
                        Tour_TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TourPhoto_TourPhotoId, t.Tour_TourId })
                .ForeignKey("dbo.TourPhotos", t => t.TourPhoto_TourPhotoId, cascadeDelete: true)
                .ForeignKey("dbo.Tour", t => t.Tour_TourId, cascadeDelete: true)
                .Index(t => t.TourPhoto_TourPhotoId)
                .Index(t => t.Tour_TourId);
            
            CreateTable(
                "dbo.RoomHotels",
                c => new
                    {
                        Room_RoomId = c.Int(nullable: false),
                        Hotel_HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_RoomId, t.Hotel_HotelId })
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId, cascadeDelete: true)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Hotel_HotelId);
            
            AlterColumn("dbo.BlogDetails", "BlogDetailPic", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Tour", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomHotels", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.RoomHotels", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Hotels", "RatingId_RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Hotels", "LocationId_LocationId", "dbo.Locations");
            DropForeignKey("dbo.TourPhotoTours", "Tour_TourId", "dbo.Tour");
            DropForeignKey("dbo.TourPhotoTours", "TourPhoto_TourPhotoId", "dbo.TourPhotos");
            DropForeignKey("dbo.Tour", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Reservations", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Comments", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ServiceTypeId_ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Comments", "CommentTypeId_CommentTypeId", "dbo.CommentTypes");
            DropForeignKey("dbo.Tour", "RatingId_RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Tour", "LocationId_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Tour", "HotelId_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.HotelPhotoHotels", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.HotelPhotoHotels", "HotelPhoto_HotelPhotoId", "dbo.HotelPhotos");
            DropIndex("dbo.RoomHotels", new[] { "Hotel_HotelId" });
            DropIndex("dbo.RoomHotels", new[] { "Room_RoomId" });
            DropIndex("dbo.TourPhotoTours", new[] { "Tour_TourId" });
            DropIndex("dbo.TourPhotoTours", new[] { "TourPhoto_TourPhotoId" });
            DropIndex("dbo.HotelPhotoHotels", new[] { "Hotel_HotelId" });
            DropIndex("dbo.HotelPhotoHotels", new[] { "HotelPhoto_HotelPhotoId" });
            DropIndex("dbo.Reservations", new[] { "UserId_UserId" });
            DropIndex("dbo.Reservations", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Comments", new[] { "UserId_UserId" });
            DropIndex("dbo.Comments", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Comments", new[] { "CommentTypeId_CommentTypeId" });
            DropIndex("dbo.Tour", new[] { "Room_RoomId" });
            DropIndex("dbo.Tour", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Tour", new[] { "RatingId_RatingId" });
            DropIndex("dbo.Tour", new[] { "LocationId_LocationId" });
            DropIndex("dbo.Tour", new[] { "HotelId_HotelId" });
            DropIndex("dbo.Hotels", new[] { "ServiceTypeId_ServiceTypeId" });
            DropIndex("dbo.Hotels", new[] { "RatingId_RatingId" });
            DropIndex("dbo.Hotels", new[] { "LocationId_LocationId" });
            AlterColumn("dbo.BlogDetails", "BlogDetailPic", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.RoomHotels");
            DropTable("dbo.TourPhotoTours");
            DropTable("dbo.HotelPhotoHotels");
            DropTable("dbo.TourPage");
            DropTable("dbo.HotelPage");
            DropTable("dbo.Rooms");
            DropTable("dbo.TourPhotos");
            DropTable("dbo.Reservations");
            DropTable("dbo.Users");
            DropTable("dbo.CommentTypes");
            DropTable("dbo.Comments");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Ratings");
            DropTable("dbo.Tour");
            DropTable("dbo.Locations");
            DropTable("dbo.HotelPhotos");
            DropTable("dbo.Hotels");
        }
    }
}
