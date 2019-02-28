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
                Hotel = db.Hotel.ToList(),
                Room = db.Room.ToList(),
                HotelRoom = db.HotelRoom.Include(x => x.hotel).Include(z => z.room).OrderBy(y => y.HotelId).ToList()
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
                        Item.WriteLine("<div class='item'>" + $"<div class='hotel-img' style='background-image: url(/HotelItems/Images/{item.FileName});'></div>" + "</div> ");
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
                        SavePic(HotelCoverPic, item);
                    }
                    if (HotelPic != null && HotelPic.Count() > 1)
                    {
                        System.IO.File.Delete(file);
                        StreamWriter FileItem = new StreamWriter(file);
                        foreach (var item1 in HotelPic)
                        {
                            SavePic(item1, hotel);
                            FileItem.WriteLine("< div class='item'>" + $"<div class='hotel-img' style='background-image: url(images/{item1.FileName});'></div>" + "</ div > ");

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

        //Create Room -------------------------------------------------------------------

        [HttpGet]
        public ActionResult RoomCreate()
        {
            ViewBag.Statuses = db.Status.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult RoomCreate([Bind(Exclude = "RoomPic")]Room room, HttpPostedFileBase RoomPic)
        {
            if (ModelState.IsValid)
            {
                if (RoomPic != null)
                {
                    SavePic(RoomPic, room);
                }
                db.Room.Add(room);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        //-------------------------------------------------------------------

        ////Edit Room-------------------------------------------------------------------
        [HttpGet]
        public ActionResult RoomEdit(int? id)
        {
            TempData["RoomId"] = id;

            ViewBag.Statuses = db.Status.ToList();

            foreach (var item in db.Room.ToList())
            {
                if (item.RoomId == Convert.ToInt32(id))
                {
                    ViewData["RoomName"] = item.RoomName;
                    ViewData["RoomPrice"] = item.RoomPrice;
                    ViewData["RoomCapacity"] = item.RoomCapacity;
                    ViewData["RoomDescription"] = item.RoomDescription;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult RoomEdit([Bind(Exclude = "RoomPic")]Room room, HttpPostedFileBase RoomPic)
        {
            foreach (var item in db.Room.ToList())
            {

                if (item.RoomId == Convert.ToInt32(TempData["RoomId"]))
                {
                    if (RoomPic != null)
                    {
                        SavePic(RoomPic, item);
                    }

                    item.RoomName = room.RoomName;
                    item.RoomPrice = room.RoomPrice;
                    item.RoomCapacity = room.RoomCapacity;

                    item.RoomDescription = room.RoomDescription;
                    item.RoomStatus = room.RoomStatus;
                    db.SaveChanges();
                }

            }


            return RedirectToAction("Index");
        }
        ////-------------------------------------------------------------------

        //Assign Room -------------------------------------------------------------------

        [HttpGet]
        public ActionResult AssignRoom()
        {
            ViewBag.Hotels = db.Hotel.ToList();
            ViewBag.Rooms = db.Room.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AssignRoom([Bind(Exclude = "RoomId")] HotelRoom room, int[] RoomId)
        {
            if (RoomId != null)
            {
                //if hotel doesn't have a room at all(new hotel)
                if (db.HotelRoom.All(x => (x.HotelId != room.HotelId)))
                {
                    foreach (var item in RoomId)
                    {
                        HotelRoom Room = new HotelRoom()
                        {
                            RoomId = item,
                            HotelId = room.HotelId,
                            Status = 1
                        };

                        db.HotelRoom.Add(Room);
                        db.SaveChanges();
                    }
                }

                //if hotel already has a room
                foreach (var item in RoomId)
                {
                    if (db.HotelRoom.Any(x => (x.HotelId.Equals(room.HotelId)) && (x.RoomId.Equals(item))))
                    {
                        
                    }
                    else
                    {
                        HotelRoom Room = new HotelRoom()
                        {
                            RoomId = item,
                            HotelId = room.HotelId,
                            Status=1
                            
                        };

                        db.HotelRoom.Add(Room);
                        db.SaveChanges();
                    }
                }
            }
        
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        // Delete room-------------------------------------------------------------------
        public ActionResult RoomDelete(int? hotelId,int? RoomId)
        {
            foreach(var item in db.HotelRoom.ToList())
            {
                if(item.HotelId== hotelId && item.RoomId== RoomId)
                {
                    db.HotelRoom.Remove(item);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------

        //to upload photos to the database 

        //Hotel Page
        public void SavePic(HttpPostedFileBase HotelPageBackPic, HotelPage hotelPage)
        {
            var fileName = HotelPageBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            HotelPageBackPic.SaveAs(FilePath);
            hotelPage.HotelPageBackPic = fileName;
            db.SaveChanges();
        }

        //hotel
        public void SavePic(HttpPostedFileBase Pics, Hotel hotel)
        {
            var fileName = Pics.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/HotelItems/Images"), fileName);
            Pics.SaveAs(FilePath);
            hotel.HotelCoverPic = fileName;
            db.SaveChanges();
        }

        //room
        public void SavePic(HttpPostedFileBase Pic, Room room)
        {
            var fileName = Pic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/HotelItems/Images"), fileName);
            Pic.SaveAs(FilePath);
            room.RoomPic = fileName;
            db.SaveChanges();
        }
        //------------------------------------------------------------------

    }
}