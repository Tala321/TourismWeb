using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        TourismDbContext db = new TourismDbContext();
        // GET: Public/Base
        public BaseController()
        {
            LayoutViewModel LayoutViewModel = new LayoutViewModel();

            LayoutViewModel.Admin = db.Admin.ToList();

            ViewBag.LayoutModel = LayoutViewModel;

        }
    }
}