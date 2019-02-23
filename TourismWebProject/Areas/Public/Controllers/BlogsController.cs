using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class BlogsController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Blogs
        public ActionResult Index(int? id)
        {
            ViewData["CategoryId"] = id;

            BlogViewModel blogViewModel = new BlogViewModel()
            {
                blogCategories = db.BlogCategory.ToList(),
                blogItems = db.BlogItem.ToList(),
                blogPage = db.BlogPage.ToList()
            };
            ViewData["Admin"] = db.Admin.ToList();
            return View(blogViewModel);
        }

        //Single Blog
        public ActionResult Single(int? id)
        {
            var dir = Server.MapPath("~\\BlogItems");

            foreach (var item in db.BlogItem.ToList())
            {
                if (item.BlogItemId == id)
                {
                    ViewData["BlogItemId"] = id;
                    ViewData["BlogItemTitle"] = item.BlogItemTitle;
                    ViewData["admin"] = db.Admin.ToList();
                    var file = Path.Combine(dir, item.BlogItemSource);
                    var fileContent = System.IO.File.ReadAllText(file);
                    ViewData["BlogItem"] = fileContent;

                }
            }

            BlogViewModel blogViewModel = new BlogViewModel()
            {
                blogCategories = db.BlogCategory.ToList(),
                blogItems = db.BlogItem.ToList(),
                blogPage = db.BlogPage.ToList()
            };
            return View(blogViewModel);
        }
    }
}