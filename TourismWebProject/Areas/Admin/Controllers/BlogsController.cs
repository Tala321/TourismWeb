using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Admin/Blogs
        public ActionResult Index()
        {
            return View();
        }
    }
}