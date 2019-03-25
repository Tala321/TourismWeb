using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class HomeController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Home
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                HomePage=db.HomePage.ToList(),
                BlogItem=db.BlogItem.Include(w => w.BlogCategory).OrderByDescending(i => i.BlogItemId).Take(4).ToList(),
                Comment =db.Comment.Where(i=>i.Status== "Approved").Include(w => w.User).OrderByDescending(i => i.CommentId).Take(3).ToList(),
                Hotel =db.Hotel.Where(i=>i.RatingId>=4 && i.HotelStatus==1).OrderByDescending(i => i.HotelId).Take(5).ToList(),
                Tour=db.Tours.Where(r=>r.TourStatus==1).Include(w=>w.Hotel).OrderByDescending(i=>i.TourId).Take(5).ToList()
            };
            return View(homeViewModel);
        }
    }
}