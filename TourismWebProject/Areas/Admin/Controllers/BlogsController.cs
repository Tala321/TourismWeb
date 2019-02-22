using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            BlogViewModel blogViewModel = new BlogViewModel()
            {
                blogPage = db.BlogPage.ToList(),
                blogItems = db.BlogItem.ToList(),
                blogCategories = db.BlogCategory.ToList()
            };

            return View(blogViewModel);
        }

        //Edit Main Page-------------------------------------------------------------------
        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["BlogPageId"] = id;

            foreach (var item in db.BlogPage.ToList())
            {
                if (item.BlogId == Convert.ToInt32(id))
                {
                    ViewData["BlogPageBackPicText"] = item.BlogBackPicText.ToString();
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult MainEdit([Bind(Exclude = "BlogtBackPic")]BlogPage blogPage, HttpPostedFileBase BlogtBackPic)
        {
            foreach (var item in db.BlogPage.ToList())
            {
                try
                {
                    if (item.BlogId == Convert.ToInt32(TempData["BlogPageId"]))
                    {
                        if (blogPage.BlogBackPicText.Length > 0)
                        {
                            item.BlogBackPicText = blogPage.BlogBackPicText;
                        }
                        if (BlogtBackPic != null)
                        {
                            //SavePic(BlogBackPic, item);

                        }
                        db.SaveChanges();
                    }
                }
                catch
                {
                    break;
                }
            }
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        ////Edit Blog item-------------------------------------------------------------------
        [HttpGet]
        public ActionResult BlogItemEdit(int? id)
        {
            TempData["BlogItemId"] = id;

            var dir = Server.MapPath("~\\BlogItems");



            foreach (var item in db.BlogItem.ToList())
            {
                if (item.BlogItemId == Convert.ToInt32(id))
                {
                    var file = Path.Combine(dir, item.BlogItemSource);
                    var fileContent = System.IO.File.ReadAllText(file);
                    ViewData["BlogItem"] = fileContent;
                }
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult BlogItemEdit([Bind(Exclude = "BlogItemPic")] BlogItem blogItem, HttpPostedFileBase BlogItemPic)
        //{
        //    foreach (var item in db.BlogItem.ToList())
        //    {
        //        try
        //        {
        //            if (item.BlogItemId == Convert.ToInt32(TempData["BlogItemId"]))
        //            {
        //                if (blogItem.BlogItemText.Length > 0)
        //                {
        //                    item.BlogItemText = blogItem.BlogItemText;
        //                }
        //                if (BlogItemPic != null)
        //                {
        //                    SavePic(BlogItemPic, item);

        //                }
        //                db.SaveChanges();
        //            }
        //        }
        //        catch
        //        {
        //            break;
        //        }
        //    }
        //    return RedirectToAction("Index");
       // }
        ////-------------------------------------------------------------------

        //Create Blog item-------------------------------------------------------------------

        [HttpGet]
        public ActionResult BlogItemCreate()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogItemCreate(BlogItem blogItem)
        {
            var num = db.BlogItem.OrderByDescending(x => x.BlogItemId).First().BlogItemId;
            var blogCount = num + 1;

            var dir = Server.MapPath("~\\BlogItems");

            var fileName = "blogItem" + blogCount + ".txt";
            var file = Path.Combine(dir, fileName);

            StreamWriter tw = new StreamWriter(file);
            tw.WriteLine(blogItem.BlogItemSource);
            tw.Close();
            blogItem.BlogItemSource = fileName;
            blogItem.AdminId = 1;//Admin example===========================================================
            db.BlogItem.Add(blogItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------


        //to upload photos to the database (Blog page)
        public void SavePic(HttpPostedFileBase BlogtBackPic, BlogPage blogPage)
        {
            var fileName = BlogtBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            BlogtBackPic.SaveAs(FilePath);
            blogPage.BlogtBackPic = fileName;
            db.SaveChanges();
        }
        //------------------------------------------------------------------

        //to upload photos to the database ( Blog item)
        public void SavePic(HttpPostedFileBase BlogtBackPic, BlogItem blogItem)
        {
            var fileName = BlogtBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            BlogtBackPic.SaveAs(FilePath);
            db.SaveChanges();
        }
        //------------------------------------------------------------------
    }
}