using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourismWebProject.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ToursController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Tours
        public ActionResult Index()
        {
            TourViewModel tourViewModel = new TourViewModel()
            {
                TourPage = db.TourPage.ToList(),
                Tour = db.Tours.Include(x => x.Hotel).ToList()
            };

            ViewData["Country"] = TempData["CountryName"];
            ViewData["City"] = TempData["CityName"];

            ViewData["PageNum"] = TempData["PageNum"];
            return View(tourViewModel);
        }

        //Single Tour
        public ActionResult Single(int? id)
        {
            if (id != null && db.Hotel.Any(i => i.HotelId == id))
            {
                foreach (var item in db.Tours.Include(i => i.Hotel).ToList())
                {
                    if (item.TourId == id)
                    {
                        TempData["HotelId"] = item.Hotel.HotelId;
                        CheckAvailablePlace(Convert.ToInt32(id), item.Hotel.HotelId);

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

                //show available number of travelers
                CountTravelers();

                TourViewModel tourViewModel = new TourViewModel()
                {
                    TourPage = db.TourPage.ToList(),
                    Tour = db.Tours.Include(x => x.Hotel).ToList()
                };
                ViewData["NoPlaces"] = TempData["NoPlaces"];
                ViewData["BookeStatus"] = TempData["BookStatus"];
                ViewBag.AvailablePlace = TempData["TravelersNum"];
                ViewBag.Rooms = db.Room.ToList();
                return View(tourViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //get items in a particular page
        public ActionResult Page(int? id)
        { int TourItemCount = (Convert.ToInt32(id) - 1) * 6;

            if (id != null && TourItemCount < db.Tours.OrderByDescending(i => i.TourId).First().TourId)
            {
                TempData["PageNum"] = id - 1;
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //--------------

        // booking
        public ActionResult Booking(Room room, Tour tour)
        {
            TempData["BookStatus"] = 2;
            if (room.RoomCapacity != 0)
            {
                var amount = 0;
                foreach (var item in db.Tours.Where(i => i.TourId == tour.TourId).ToList())
                {
                    amount = item.TourPrice * room.RoomCapacity;
                   
                }

                TempData["TourId"] = tour.TourId;
                TempData["UserId"] = Convert.ToInt32(Session["UserLog"]);
                TempData["Total"] = amount;
                return RedirectToAction("ConfirmBooking");
            }
            return RedirectToAction("Single/" + tour.TourId.ToString());
        }
        //search
        public ActionResult Search(Hotel hotel)
        {
            //Country ,city
            if (hotel.HotelCity != null && hotel.HotelCountry != null )
            {
                var count = 0;
                foreach (var item in db.Hotel.ToList())
                {
                    if (item.HotelCountry == hotel.HotelCountry && item.HotelCity == hotel.HotelCity)
                    {
                        count++;
                        TempData["CountryName"] = item.HotelCountry;
                        TempData["CityName"] = item.HotelCity;
                        break;
                    }
                }
                if (count == 0)
                {
                    TempData["CountryName"] = "No such country";
                    TempData["CityName"] = "No such city";
                }
            }

            //if only country selected
            if (hotel.HotelCity == null)
            {
                var count = 0;
                foreach (var item in db.Hotel.ToList())
                {
                    if (hotel.HotelCountry == item.HotelCountry)
                    {
                        count++;
                        TempData["CountryName"] = item.HotelCountry;
                        break;
                    }
                }

                if (count == 0)
                {
                    TempData["CountryName"] = "No such country";
                }
            }
            return RedirectToAction("Index");
        }


        //Confirm payment
        public ActionResult ConfirmBooking()
        {

            return View();
        }

        //after successful payment
        public ActionResult Successful()
        {
            TempData["BookStatus"] = 1;
            TourList tourList = new TourList();
            tourList.UserId = Convert.ToInt32(TempData["UserId"]);
            tourList.TourId = Convert.ToInt32(TempData["TourId"]);
            tourList.Total = Convert.ToInt32(TempData["Total"]);

            db.TourList.Add(tourList);
            db.SaveChanges();

            return RedirectToAction("Single/" + TempData["TourId"].ToString());
        }

        //Number of travelers for a tour
        public void CountTravelers()
        {
            int count = Convert.ToInt32(TempData["HotelId"]);
            List<int> Numer = new List<int>();
            int Num = 0;
            if (TempData["LeftPlaces"] == null)
            {
               
                foreach (var item in db.HotelRoom.Where(i => i.HotelId == count).ToList())
                {
                    if (item.RoomId == 1)
                    {
                        Num += 1;
                    }
                    if (item.RoomId == 2)
                    {
                        Num += 2;
                    }
                    if (item.RoomId == 3)
                    {
                        Num += 7;
                    }
                }
                for (var i = 0; i <= Num; i++)
                {
                    Numer.Add(i);
                }
                TempData["TravelersNum"] = Numer;
            }
            else
            {
                for (var i = 0; i <= Convert.ToInt32(TempData["LeftPlaces"]); i++)
                {
                    Numer.Add(i);
                }
                TempData["TravelersNum"] = Numer;
            }

           
        }

        //check available places
        public void CheckAvailablePlace(int tourId, int hoteilId)
        {
            int TourId = tourId;

            // check if tour already exist in this list
            if (db.TourList.Any(i => i.TourId == TourId))
            {
                int total = 0;
                int people = 0;
                int tourCost = 0;

                int HotelId = hoteilId;

                //to get the amout of money from tourlist
                foreach (var item in db.TourList.Include(i => i.Tour).Where(i => i.TourId == TourId))
                {
                    total += item.Total;
                    tourCost = item.Tour.TourPrice;
                }

                //to calculate people
                foreach (var item in db.HotelRoom.Where(i => i.HotelId == HotelId).Include(i => i.room))
                {
                    people += item.room.RoomCapacity;
                }

                //calculate how much money we have, and available places for people
                int ExpectedAmount = tourCost * people;
                if ((ExpectedAmount - total) == 0)
                {
                    TempData["NoPlaces"] = 0;
                }
                else
                {
                    int LeftPlaces = (ExpectedAmount - total) / tourCost;
                    TempData["LeftPlaces"] = LeftPlaces;
                    TempData["NoPlaces"] = 1;

                }
            }
            else
            {
                TempData["NoPlaces"] = 1;
                CountTravelers();
            }
        }
    }
}