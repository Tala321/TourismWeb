using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class AboutController : Controller
    {
        // GET: Public/About
        public ActionResult Index()
        {
            return View();
        }
    }
}