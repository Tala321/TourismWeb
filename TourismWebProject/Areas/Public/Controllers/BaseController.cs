using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
namespace TourismWebProject.Areas.Public.Controllers
{
    public class BaseController : Controller
    {
        TourismDbContext db = new TourismDbContext();
        // GET: Public/Base
        public BaseController()
        {
            LayoutViewModel LayoutViewModel = new LayoutViewModel();

            LayoutViewModel.ContactPage = db.ContactPage.ToList();

            LayoutViewModel.MainMenu = db.MainMenu.ToList();

            ViewBag.LayoutModel = LayoutViewModel;

        }
    }
}