using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class AboutController : Controller
    {
        TourismDbContext db = new TourismDbContext();
        // GET: Public/About
        public ActionResult Index()
        {
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                AboutItem = db.AboutItem.ToList(),
                AboutPage = db.AboutPage.ToList(),
                Faqs = db.Faq.ToList()
                
            };
            return View(aboutViewModel);
        }
    }
}