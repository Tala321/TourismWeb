using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class TourismDbContext: DbContext
    {
        public TourismDbContext():base("TourismWebsiteConn") { }

        public DbSet<AboutItem> AboutItem { get; set; }

        public DbSet<AboutPage> AboutPage { get; set; }

        public DbSet<Advantage> Advantage { get; set; }

        public DbSet<ContactPage> ContactPage { get; set; }

        public DbSet<Fact> Fact { get; set; }

        public DbSet<Faq> Faq { get; set; }

        public DbSet<HomePage> HomePage { get; set; }

        public DbSet<MainMenu> MainMenu { get; set; }

        public DbSet<SocialMediaLink> SocialMediaLink { get; set; }

        public DbSet<ContactForm> ContactForm { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<UserType> UserType { get; set; }

        public DbSet<BlogPage> BlogPage { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<BlogCategory> BlogCategory { get; set; }

        public DbSet<BlogItem> BlogItem { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<HotelPage> HotelPage { get; set; }

        public DbSet<HotelPhoto> HotelPhoto { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<TourPhoto> TourPhoto { get; set; }

        public DbSet<Tour> Tour { get; set; }

        public DbSet<TourPage> TourPage { get; set; }

        public DbSet<ServiceType> ServiceType { get; set; }

        public DbSet<Status> Status { get; set; }
    }
}