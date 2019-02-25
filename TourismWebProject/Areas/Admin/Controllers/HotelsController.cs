using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
using System.IO;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class HotelsController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Hotels
        public ActionResult Index()
        {
            HotelViewModel hotelViewModel = new HotelViewModel()
            {
                HotelPage = db.HotelPage.ToList(),
                Hotel = db.Hotel.ToList()
            };
            return View(hotelViewModel);
        }

        //Edit Main Page-------------------------------------------------------------------
        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["HotelPageId"] = id;

            foreach (var item in db.HotelPage.ToList())
            {
                if (item.HotelPageId == Convert.ToInt32(id))
                {
                    ViewData["HotelPageBackPicText"] = item.HotelPageBackPicText.ToString();
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult MainEdit([Bind(Exclude = "HotelPageBackPic")]HotelPage hotelPage, HttpPostedFileBase HotelPageBackPic)
        {
            foreach (var item in db.HotelPage.ToList())
            {
                try
                {
                    if (item.HotelPageId == Convert.ToInt32(TempData["HotelPageId"]))
                    {
                        if (hotelPage.HotelPageBackPicText.Length > 0)
                        {
                            item.HotelPageBackPicText = hotelPage.HotelPageBackPicText;
                        }
                        if (HotelPageBackPic != null)
                        {
                            SavePic(HotelPageBackPic, item);
                        }
                        db.SaveChanges();
                    }
                }
                catch
                {
                    break;
                }
            }
            return RedirectToAction("Index");
        }


        //Create Hotel -------------------------------------------------------------------

        [HttpGet]
        public ActionResult HotelCreate()
        {
            ViewBag.StarRating = db.Rating.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult HotelCreate([Bind(Exclude = "HotelPic")]Hotel hotel, IEnumerable<HttpPostedFileBase> HotelPic, HttpPostedFileBase HotelCoverPic)
        {
            if (ModelState.IsValid)
            {
                var num = db.Hotel.OrderByDescending(x => x.HotelId).First().HotelId;
                var hotelCount = num + 1;
                var dir = Server.MapPath("~\\HotelItems");

                var fileName = "hotelItems" + hotelCount + ".txt";
                var file = Path.Combine(dir, fileName);
                StreamWriter Item = new StreamWriter(file);

                if (HotelCoverPic != null)
                {
                    SavePic(HotelCoverPic, hotel);
                }

                if (HotelPic != null)
                {
                    foreach (var item in HotelPic)
                    {
                        SavePic(item, hotel);
                        Item.WriteLine("< div class='item'>" + $"<div class='hotel-img' style='background-image: url(images/{item.FileName});'></div>" + "</ div > ");

                    }
                }

                Item.Close();

                hotel.HotelPic = fileName;
                hotel.HotelStatus = 1;
                hotel.ServiceTypeId = 1;
                db.Hotel.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        ////Edit Hotel-------------------------------------------------------------------
        [HttpGet]
        public ActionResult HotelEdit(int? id)
        {
            TempData["HotelId"] = id;

            ViewBag.Ratings = db.Rating.ToList();
            ViewBag.Statuses = db.Status.ToList();

            foreach (var item in db.Hotel.ToList())
            {
                if (item.HotelId == Convert.ToInt32(id))
                {
                    ViewData["HotelName"] = item.HotelName;
                    ViewData["HotelAddress"] = item.HotelAddress;
                    ViewData["HotelDescription"] = item.HotelDescription;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult HotelEdit([Bind(Exclude = "HotelPic,HotelCoverPic")]Hotel hotel, IEnumerable<HttpPostedFileBase> HotelPic, HttpPostedFileBase HotelCoverPic)
        {

            foreach (var item in db.Hotel.ToList())
            {
                var dir = Server.MapPath("~\\HotelItems");
                var file = Path.Combine(dir, item.HotelPic);

                if (item.HotelId == Convert.ToInt32(TempData["HotelId"]))
                {
                    if (HotelCoverPic != null)
                    {
                        SavePic(HotelCoverPic, hotel);
                    }
                    if (HotelPic != null && HotelPic.Count() > 1)
                    {
                        System.IO.File.Delete(file);
                        StreamWriter FileItem = new StreamWriter(file);                     
                        foreach (var item1 in HotelPic)
                        {
                            SavePic(item1, hotel);
                            FileItem.WriteLine( "< div class='item'>" + $"<div class='hotel-img' style='background-image: url(images/{item1.FileName});'></div>" + "</ div > ");
                            
                        }
                        FileItem.Close();
                    }

                    if (hotel.HotelCountry != null && hotel.HotelCity != null)
                    {
                        item.HotelCountry = hotel.HotelCountry;
                        item.HotelCity = hotel.HotelCity;
                    }
                    item.HotelName = hotel.HotelName;
                    item.HotelAddress = hotel.HotelAddress;
                    item.HotelDescription = hotel.HotelDescription;

                    item.RatingId = hotel.RatingId;
                    item.HotelStatus = hotel.HotelStatus;
                    db.SaveChanges();
                }

            }


            return RedirectToAction("Index");
        }
        ////-------------------------------------------------------------------


        //to upload photos to the database (Blog page)
        public void SavePic(HttpPostedFileBase HotelPageBackPic, HotelPage hotelPage)
        {
            var fileName = HotelPageBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            HotelPageBackPic.SaveAs(FilePath);
            hotelPage.HotelPageBackPic = fileName;
            db.SaveChanges();
        }


        public void SavePic(HttpPostedFileBase Pics, Hotel hotel)
        {
            var fileName = Pics.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/HotelItems/Images"), fileName);
            Pics.SaveAs(FilePath);
            hotel.HotelPic = fileName;
            db.SaveChanges();
        }
        //------------------------------------------------------------------

    }
}