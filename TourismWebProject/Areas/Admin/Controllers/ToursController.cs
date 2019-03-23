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
    [AdminAuthenticate]
    public class ToursController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Tours
        public ActionResult Index()
        {
            TourViewModel tourViewModel = new TourViewModel()
            {
                Tour = db.Tour.Include(i => i.Hotel).ToList(),
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
            //possibility to book only during the year// refresh page if the below statement is false
            if (tour.DateFrom > DateTime.Today && tour.DateTo > DateTime.Today)
            {
                if (tour.DateFrom < tour.DateTo)
                {

                    //get the number of booked hotel  in the reservation list
                    var countofReservation = db.Reservation.Where(i => (i.ReservationServiceTypeId == tour.HotelId && i.ReservationStatus==true) && (i.ReservationDateFrom.Month == tour.DateFrom.Month || i.ReservationDateTo.Month == tour.DateTo.Month || i.ReservationDateTo.Month == tour.DateFrom.Month)).Count();

                    //uses to check avilability of dates (counts rooms)
                    var CheckCount = 0;

                    var dateFrom = tour.DateFrom;
                    var dateTo = tour.DateTo;

                    //calculate max reservation period (max 30 days)
                    int Month = dateTo.Month - dateFrom.Month;

                    int Days = dateTo.Day - dateFrom.Day;

                    //to count total
                    TempData["Total"] = Days;

                    int Reservationlimit = 0;

                    var count = 0;

                    if (Month == 1)
                    {
                    
                        Reservationlimit = 31 - dateFrom.Day + dateTo.Day;
                        //to count total
                        TempData["Total"] = Reservationlimit;
                    }
                    //-----

                    if (tour.DateFrom != null && tour.DateTo != null)
                    {
                        //check max stay period (30 days)
                        if (Month == 0 || Month == 1 && Reservationlimit < 32)
                        {
                            foreach (var item in db.Reservation.Where(i => (i.ReservationServiceTypeId == tour.HotelId && i.ReservationStatus == true) && (i.ReservationDateFrom.Month == tour.DateFrom.Month || i.ReservationDateTo.Month == tour.DateTo.Month || i.ReservationDateTo.Month == tour.DateFrom.Month || i.ReservationDateFrom.Month == tour.DateTo.Month)).ToList())
                            {
                                count++;
                                //--
                                if (Month == 1)
                                {
                                    if (item.ReservationDateFrom.Month == item.ReservationDateTo.Month)
                                    {
                                        if (dateFrom.Month == item.ReservationDateFrom.Month && dateFrom.Day > item.ReservationDateTo.Day)
                                        {

                                            if (countofReservation == CheckCount)
                                            {

                                                return true;
                                            }
                                        }
                                    }
                                    else if ((dateFrom.Month == item.ReservationDateFrom.Month && dateFrom.Day < item.ReservationDateFrom.Day || dateFrom.Month == item.ReservationDateTo.Month && dateFrom.Day > item.ReservationDateTo.Day) && dateTo.Month != item.ReservationDateTo.Month)
                                    {
                                        CheckCount++;

                                        if (countofReservation == CheckCount)
                                        {
                                            return true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (dateFrom.Month == item.ReservationDateFrom.Month && dateFrom.Day < item.ReservationDateFrom.Day && item.ReservationDateFrom.Day > dateTo.Day || dateTo.Month == item.ReservationDateTo.Month && dateFrom.Day > item.ReservationDateTo.Day && item.ReservationDateTo.Day < dateTo.Day)
                                    {
                                        CheckCount++;

                                        if (countofReservation == CheckCount)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                            //if there is no such hotel in the reservation list
                            if (count == 0)
                            {
                                //Reservation(reservation, hotel, room);
                                return true;
                            }
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
                    ReservationTotal = item.room.RoomPrice * Convert.ToInt32(TempData["Total"])
                };
                db.Reservation.Add(TourReservation);
                db.SaveChanges();
            }
        }
    }
}