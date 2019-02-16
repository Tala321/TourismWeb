using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ToursController : Controller
    {
        // GET: Public/Tours
        public ActionResult Index()
        {
            return View();
        }

        //Single Tour
        public ActionResult Single()
        {
            return View();
        }
    }
}