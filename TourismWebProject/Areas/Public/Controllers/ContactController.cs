using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ContactController : Controller
    {
        // GET: Public/Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}