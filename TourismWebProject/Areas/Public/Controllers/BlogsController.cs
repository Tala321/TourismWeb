using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Public/Blogs
        public ActionResult Index()
        {
            return View();
        }

        //Single Blog
        public ActionResult Single()
        {
            return View();
        }
    }
}