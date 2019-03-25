using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using TourismWebProject.Models;
namespace TourismWebProject.Areas.Admin.Controllers
{
    public class ReservationController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Reservation
        public ActionResult Index()
        {
            ReservationViewModel reservationView = new ReservationViewModel()
            {
                reservation = db.Reservation.Include(c=>c.ServiceType).ToList(),
                tourList = db.TourList.Include(r=>r.Tour).ToList()
            };

            ViewData["Hotels"] = db.Hotel.Include(x => x.HotelRoom).ToList();
            ViewData["Rooms"] = db.Room.ToList();

            return View(reservationView);
        }
    }
}