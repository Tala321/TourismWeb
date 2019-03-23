using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class BlogsController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Blogs
        public ActionResult Index()
        {


            BlogViewModel blogViewModel = new BlogViewModel()
            {
                blogCategories = db.BlogCategory.ToList(),
                blogItems = db.BlogItem.ToList(),
                blogPage = db.BlogPage.ToList(),

            };
            ViewData["CategoryId"] = TempData["CategoryId"];
            ViewData["PageNum"] = TempData["PageNum"];
            ViewData["Admin"] = db.Admin.ToList();
            return View(blogViewModel);
        }

        //Single Blog
        public ActionResult Single(int? id)
        {
            if (id != null && db.BlogItem.Any(i => i.BlogItemId == id))
            {
                var dir = Server.MapPath("~\\BlogItems");

                foreach (var item in db.BlogItem.ToList())
                {
                    if (item.BlogItemId == id)
                    {
                        TempData["BlogItemId"] = id;
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
                    blogPage = db.BlogPage.ToList(),
                    comments = db.Comment.Include(x => x.User).ToList()
                };
                return View(blogViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Category
        public ActionResult Category(int? id)
        {
            if (id != null && db.BlogCategory.Any(i => i.BlogCategoryId == id))
            {
                TempData["CategoryId"] = id;

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        //Comment
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            if (comment != null)
            {
                comment.Status = "Not Approved";
                comment.CommentDate = DateTime.Now;
                comment.UserId = Convert.ToInt32(Session["UserLog"]);
                db.Comment.Add(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Single/" + TempData["BlogItemId"]);

        }

        //get items in a particular page
        public ActionResult Page(int? id)
        {
            int BlogItemCount = (Convert.ToInt32(id) - 1) * 8;

            if (id != null && BlogItemCount < db.BlogItem.OrderByDescending(i => i.BlogItemId).First().BlogItemId)
            {
                TempData["PageNum"] = id - 1;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}