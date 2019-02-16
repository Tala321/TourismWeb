using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class HotelsController : Controller
    {
        // GET: Public/Hotels
        public ActionResult Index()
        {
            return View();
        }

        //Single Hotel
        public ActionResult Single()
        {
            return View();
        }

    }
}