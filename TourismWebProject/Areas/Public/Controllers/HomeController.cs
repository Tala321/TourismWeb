using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        // GET: Public/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}