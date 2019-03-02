using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourismWebProject.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ToursController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Tours
        public ActionResult Index()
        {
            TourViewModel tourViewModel = new TourViewModel()
            {
                TourPage = db.TourPage.ToList(),
                Tour = db.Tour.Include(x => x.Hotel).ToList()
            };

            ViewData["PageNum"] = TempData["PageNum"];
            return View(tourViewModel);
        }

        //Single Tour
        public ActionResult Single(int? id)
        {
            foreach (var item in db.Tour.Include(i=>i.Hotel).ToList())
            {
                if (item.TourId == id)
                {
                    ViewData["TourId"] = id;
                    ViewData["TourName"] = item.TourName;
                    ViewData["TourPic"] = item.TourPic;
                    ViewData["TourDescription"] = item.TourDescription;
                    ViewData["TourPrice"] = item.TourPrice;
                    ViewData["DateFrom"] = item.DateFrom.ToString("dd/MM/yyyy");
                    ViewData["DateTo"] = item.DateTo.ToString("dd/MM/yyyy");
                    ViewData["HotelName"] = item.Hotel.HotelName;
                    ViewData["HotelCountry"] = item.Hotel.HotelCountry;
                    ViewData["CityName"] = item.Hotel.HotelCity;
                }
            }

            TourViewModel tourViewModel = new TourViewModel()
            {
                TourPage = db.TourPage.ToList(),
                Tour = db.Tour.Include(x => x.Hotel).ToList()
            };

            ViewBag.Rooms = db.Room.ToList();
            return View(tourViewModel);
        }

        //get items in a particular page
        public ActionResult Page(int? id)
        {
            TempData["PageNum"] = id - 1;
            return RedirectToAction("Index");
        }
        //--------------
    }
}