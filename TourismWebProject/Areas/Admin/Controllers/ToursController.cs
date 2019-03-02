using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TourismWebProject.Models;
using System.IO;
using System.Data.Entity.SqlServer;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Tours
        public ActionResult Index()
        {
            TourViewModel tourViewModel = new TourViewModel()
            {
                Tour = db.Tour.Include(i=>i.Hotel).ToList(),
                TourPage = db.TourPage.ToList()
               
            };
         
            return View(tourViewModel);
        }



        //Edit Main Page-------------------------------------------------------------------
        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["TourPageId"] = id;

            foreach (var item in db.TourPage.ToList())
            {
                if (item.ToursPageId == Convert.ToInt32(id))
                {
                    ViewData["TourPageBackPicText"] = item.ToursPageBackPicText.ToString();
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult MainEdit([Bind(Exclude = "ToursPageBackPic")]TourPage tourPage, HttpPostedFileBase ToursPageBackPic)
        {
            foreach (var item in db.TourPage.ToList())
            {
                try
                {
                    if (item.ToursPageId == Convert.ToInt32(TempData["TourPageId"]))
                    {
                        if (tourPage.ToursPageBackPicText.Length > 0)
                        {
                            item.ToursPageBackPicText = tourPage.ToursPageBackPicText;
                        }
                        if (ToursPageBackPic != null)
                        {
                            SavePic(ToursPageBackPic, item);
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

        //-------------------------------------

        //Create Tour -------------------------------------------------------------------

        [HttpGet]
        public ActionResult TourCreate()
        {
            ViewBag.Hotels = db.Hotel.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult TourCreate([Bind(Exclude = "TourPic")]Tour tour, HttpPostedFileBase TourPic)
        {
            if (Checking(tour))
            {
                if (TourPic != null)
                {
                    SavePic(TourPic, tour);
                }

                tour.TourStatus = 1;
                tour.ServiceTypeId = 2;
                db.Tour.Add(tour);

                //add to reservation
                AddReservation(tour);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        //Edit Tour -------------------------------------------------------------------

        [HttpGet]
        public ActionResult TourEdit(int? id)
        {
            TempData["TourId"] = id;

            ViewBag.Statuses = db.Status.ToList();

            foreach (var item in db.Tour.ToList())
            {
                if (item.TourId == Convert.ToInt32(id))
                {
                    ViewData["TourName"] = item.TourName;
                    ViewData["TourPrice"] = item.TourPrice;
                    ViewData["HotelDescription"] = item.TourDescription;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult TourEdit([Bind(Exclude = "TourPic")]Tour tour, HttpPostedFileBase TourPic)
        {

            foreach (var item in db.Tour.ToList())
            {
                if (item.TourId == Convert.ToInt32(TempData["TourId"]))
                {

                    if (TourPic != null)
                    {
                        SavePic(TourPic, item);
                    }
                    item.TourStatus = tour.TourStatus;
                    item.TourName = tour.TourName;
                    item.TourPrice = tour.TourPrice;
                    item.TourDescription = tour.TourDescription;
                    db.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        //to upload photos to the database ------------------

        //Tour Page
        public void SavePic(HttpPostedFileBase ToursPageBackPic, TourPage tourPage)
        {
            var fileName = ToursPageBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            ToursPageBackPic.SaveAs(FilePath);
            tourPage.ToursPageBackPic = fileName;
            db.SaveChanges();
        }

        //tour item
        public void SavePic(HttpPostedFileBase Photo, Tour tour)
        {
            var fileName = Photo.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            Photo.SaveAs(FilePath);
            tour.TourPic = fileName;
            db.SaveChanges();
        }

        //------------------------------------------------------------------


        //check hotel for  availability
        public bool Checking(Tour tour)
        {
            if (tour.DateFrom.Year == DateTime.Today.Year && tour.DateTo.Year == DateTime.Today.Year && tour.DateFrom.Month >= DateTime.Today.Month && tour.DateTo.Month >= DateTime.Today.Month)
            {
                if (tour.DateFrom < tour.DateTo)
                {
                    //uses to check avilability of dates (counts rooms)
                    var CheckCount = 0;

                    var dateFrom = tour.DateFrom;
                    var dateTo = tour.DateTo;

                    //calculate max reservation period (max 30 days)
                    int Month = dateTo.Month - dateFrom.Month;

                    int Days = dateTo.Day - dateFrom.Day;

                    int Reservationlimit = 0;

                    //get the number of booked hotel  in the reservation list
                    var Hotelcount = db.Reservation.Where(i => i.ReservationServiceTypeId == tour.HotelId).Count();

                    if (Month == 1)
                    {
                        Reservationlimit = 31 - dateFrom.Day + dateTo.Day;
                    }

                    //check max stay period (30 days)
                    if (Month == 0 || Month == 1 && Reservationlimit < 32)
                    {
                        foreach (var item in db.Reservation.Where(i => (i.ReservationServiceTypeId == tour.HotelId) && SqlFunctions.DatePart("dayofyear", i.ReservationDateFrom) < tour.DateFrom.DayOfYear && SqlFunctions.DatePart("dayofyear", i.ReservationDateTo) < tour.DateFrom.DayOfYear || (i.ReservationServiceTypeId == tour.HotelId) && SqlFunctions.DatePart("dayofyear", i.ReservationDateFrom) > tour.DateTo.DayOfYear && SqlFunctions.DatePart("dayofyear", i.ReservationDateTo) > tour.DateTo.DayOfYear))
                        {
                            CheckCount++;
                            if (Hotelcount == CheckCount)
                            {
                                return true;
                            }
                        }

                        if (CheckCount == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //add reservation
        public void AddReservation(Tour tour)
        {

            foreach (var item in db.HotelRoom.Include(c => c.room).Where(i => i.HotelId == tour.HotelId).ToList())
            {
                //add to the reservation list
                Reservation TourReservation = new Reservation()
                {
                    ServiceTypeId = 2,
                    UserId = 1,/////change it!!!!!!!!!+===================================
                    ReservationDateFrom = tour.DateFrom,
                    ReservationDateTo = tour.DateTo,
                    ReservationServiceTypeId = tour.HotelId,
                    ReservationServiceId = item.RoomId,
                    ReservationStatus = true,
                    ReservationTotal = item.room.RoomPrice
                };
                db.Reservation.Add(TourReservation);
                db.SaveChanges();
            }
        }
    }
}