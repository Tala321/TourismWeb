using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        // GET: Admin/Tours
        public ActionResult Index()
        {
            return View();
        }
    }
}