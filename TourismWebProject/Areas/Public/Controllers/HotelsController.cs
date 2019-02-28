using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
using System.IO;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class HotelsController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Hotels
        public ActionResult Index()
        {
            //filer results see action "Search"
            ViewData["Country"] = TempData["CountryName"];
            ViewData["City"] = TempData["CityName"];
            ViewData["Rating"] = TempData["Rating"];
            ViewData["AvailableHotels"] = TempData["AvailableHotels"];
            //-----
            HotelViewModel hotelViewModel = new HotelViewModel()
            {
                Hotel = db.Hotel.Include(x => x.HotelRoom).Include(x => x.Rating).Where(i => i.HotelStatus == 1).ToList(),
                HotelPage = db.HotelPage.ToList()
            };
            ViewData["PageNum"] = TempData["PageNum"];
            ViewBag.StarRating = db.Rating.ToList();

            return View(hotelViewModel);
        }

        //Single Hotel
        public ActionResult Single(int? id)
        {
            var dir = Server.MapPath("~\\HotelItems");

            foreach (var item in db.Hotel.ToList())
            {
                if (item.HotelId == id)
                {
                    ViewData["HotelId"] = id;
                    ViewData["HotelName"] = item.HotelName;
                    ViewData["HotelAddress"] = item.HotelAddress;
                    ViewData["RatingId"] = item.RatingId;
                    ViewData["HotelAddress"] = item.HotelAddress;
                    ViewData["HotelDescription"] = item.HotelDescription;

                    ViewData["HotelCountry"] = item.HotelCountry;
                    ViewData["HotelCity"] = item.HotelCity;
                    ViewData["HotelRating"] = item.RatingId;

                    var file = Path.Combine(dir, item.HotelPic);
                    var fileContent = System.IO.File.ReadAllText(file);
                    ViewData["HotelPics"] = fileContent;

                }
            }

            HotelViewModel blogViewModel = new HotelViewModel()
            {
                Hotel = db.Hotel.Include(x => x.HotelRoom).Include(x => x.Rating).Where(f => f.HotelId != id).ToList(),
                HotelRoom = db.HotelRoom.Include(z => z.room).Include(e => e.hotel).Where(i => i.Status == 1).ToList(),
                HotelPage = db.HotelPage.ToList()
            };

            ViewBag.StarRating = db.Rating.ToList();

            return View(blogViewModel);
        }

        //get items in a particular page
        public ActionResult Page(int? id)
        {
            TempData["PageNum"] = id - 1;
            return RedirectToAction("Index");
        }

        //filter for searching hotels-------------------------------------------------
        //Possible search by:
        //1)Country,City
        //2)Country
        //3)Country,City,Rating
        //4)Country,Rating
        //5)Country ,city ,dates
        //6)Rating (website is oriented to at least "3 star rating" hotels, choosing star rating 1 or 2  will show all hotels)
        public ActionResult Search([Bind(Exclude = "ReservationDateFrom,ReservationDateTo,RoomPrice,ReservationDateFrom,ReservationDateTo")] Hotel hotel, [Bind(Include = "ReservationDateFrom,ReservationDateTo")]Reservation reservation)
        {
            //set all hotels status 1(visible)
            HotelStatus();

            //set all romms status1(available)
            RoomStatus();

            //Country ,city
            if (hotel.HotelCity != null && hotel.HotelCountry != null && Convert.ToInt32(hotel.RatingId) == 1)
            {
                foreach (var item in db.Hotel.ToList())
                {
                    if (item.HotelCountry == hotel.HotelCountry && item.HotelCity == hotel.HotelCity)
                    {
                        TempData["CountryName"] = item.HotelCountry;
                        TempData["CityName"] = item.HotelCity;
                        break;
                    }
                }
            }
            else
            {
                //if only country selected
                if (hotel.HotelCity == null && Convert.ToInt32(hotel.RatingId) == 1)
                {
                    foreach (var item in db.Hotel.ToList())
                    {
                        if (hotel.HotelCountry == item.HotelCountry)
                        {
                            TempData["CountryName"] = item.HotelCountry;
                            break;
                        }
                    }
                }
            }
            //if selected:Country,City,Rating
            if (hotel.HotelCity != null && hotel.HotelCountry != null && Convert.ToInt32(hotel.RatingId) != 1)
            {
                foreach (var item in db.Hotel.ToList())
                {
                    if (item.HotelCountry == hotel.HotelCountry && item.HotelCity == hotel.HotelCity && item.RatingId == hotel.RatingId)
                    {
                        TempData["CountryName"] = item.HotelCountry;
                        TempData["CityName"] = item.HotelCity;
                        TempData["Rating"] = item.RatingId;
                        break;
                    }
                }
            }
            //if selected:Country,Rating
            if (hotel.HotelCity == null && hotel.HotelCountry != null && Convert.ToInt32(hotel.RatingId) != 1)
            {
                foreach (var item in db.Hotel.ToList())
                {
                    if (item.HotelCountry == hotel.HotelCountry && item.RatingId == hotel.RatingId)
                    {
                        TempData["CountryName"] = item.HotelCountry;
                        TempData["Rating"] = item.RatingId;
                        break;
                    }
                }
            }
            //if selected:Rating
            if (hotel.HotelCity == null && hotel.HotelCountry == null && Convert.ToInt32(hotel.RatingId) != 1|| hotel.HotelCity == null && hotel.HotelCountry == null && Convert.ToInt32(hotel.RatingId) != 2)
            {
                foreach (var item in db.Hotel.ToList())
                {
                    if (item.RatingId == hotel.RatingId)
                    {
                        TempData["Rating"] = item.RatingId;
                        break;
                    }
                }
            }

            var dateFrom = reservation.ReservationDateFrom;
            var dateTo = reservation.ReservationDateTo;

            //if selected:Country ,city ,dates
            if (hotel.HotelCity != null && hotel.HotelCountry != null && Convert.ToInt32(hotel.RatingId) == 1 &&  dateFrom.Year !=0001 && dateTo.Year != 0001)
            {      
                List<Hotel> AvailableHotels = new List<Hotel>();

                foreach (var item in db.Hotel.ToList())
                {
                    if (item.HotelCountry == hotel.HotelCountry && item.HotelCity == hotel.HotelCity)
                    {
                        if (db.Reservation.Any(w => w.ReservationServiceTypeId == item.HotelId))
                        {
                            foreach (var item1 in db.Reservation.Where(d => d.ReservationServiceTypeId == item.HotelId).ToList())
                            {
                                foreach (var item2 in db.HotelRoom.ToList())
                                {
                                    if (item2.HotelId == item1.ReservationServiceTypeId && item2.RoomId == item1.ReservationServiceId)
                                    {
                                        //1case
                                        if (dateFrom.Month != item1.ReservationDateFrom.Month && item1.ReservationDateTo.Month != dateTo.Month)
                                        {

                                        }
                                        //2case
                                        if (dateFrom.Month == item1.ReservationDateFrom.Month && item1.ReservationDateTo.Month == dateTo.Month && dateFrom.Day < item1.ReservationDateFrom.Day && item1.ReservationDateFrom.Day > dateTo.Day || dateFrom.Day > item1.ReservationDateTo.Day && item1.ReservationDateTo.Day < dateTo.Day && dateFrom.Month == item1.ReservationDateFrom.Month && item1.ReservationDateTo.Month == dateTo.Month)
                                        {

                                        }
                                        //3case
                                        else
                                        {
                                            foreach (var item3 in db.HotelRoom.Where(s => (s.HotelId == item1.ReservationServiceTypeId) && (s.RoomId == item1.ReservationServiceId)).ToList())
                                            {//don't show  a room
                                                item3.Status = 2;
                                                db.SaveChanges();
                                            }
                                            CheckHotelAvailability(item);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    AvailableHotels.Add(item);
                    TempData["AvailableHotels"] = AvailableHotels;
                }
            }
            return RedirectToAction("Index");
        }

        //check availability of rooms of a hotel
        public void CheckHotelAvailability(Hotel hotel)
        {
            int count = 0;
            foreach (var item in db.HotelRoom.Where(i => (i.HotelId == hotel.HotelId) && (i.Status == 2)))
            {
                count++;
            }

            if (count == 3)
            {
                hotel.HotelStatus = 2;
                db.SaveChanges();
            }
        }

        //set all hotels status 1(visible)
        public void HotelStatus()
        {
            foreach (var item in db.Hotel.ToList())
            {
                item.HotelStatus = 1;
                db.SaveChanges();
            }
        }


        //set all rooms available
        public void RoomStatus()
        {
            foreach (var item in db.HotelRoom.ToList())
            {
                item.Status = 1;
                db.SaveChanges();
            }
        }
        //---------------------------------------------------------------------
    }
}
