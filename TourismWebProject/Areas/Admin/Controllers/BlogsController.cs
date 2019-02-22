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
        public ActionResult MainEdit([Bind(Exclude = "BlogBackPic")]BlogPage blogPage, HttpPostedFileBase BlogBackPic)
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
                        if (BlogBackPic != null)
                        {
                            SavePic(BlogBackPic, item);
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogItemEdit(BlogItem blogItem)
        {
            foreach (var item in db.BlogItem.ToList())
            {
                if (item.BlogItemId == Convert.ToInt32(TempData["BlogItemId"]))
                {
                    var dir = Server.MapPath("~\\BlogItems");
                    var file = Path.Combine(dir, item.BlogItemSource);
                    System.IO.File.WriteAllText(file, blogItem.BlogItemSource);
                }
            }
            return RedirectToAction("Index");
        }
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
            blogItem.DateTime = DateTime.Now;
            blogItem.AdminId = 1;//Admin example===========================================================
            db.BlogItem.Add(blogItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-------------------------------------------------------------------

        ////Create Category item-------------------------------------------------------------------
        [HttpGet]
        public ActionResult CategoryCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CategoryCreate(BlogCategory blogCategory)
        {
            db.BlogCategory.Add(blogCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ////-------------------------------------------------------------------

        ////Edit Category item-------------------------------------------------------------------
        [HttpGet]
        public ActionResult CategoryEdit(int? id)
        {
            TempData["BlogCategoryId"] = id;


            foreach (var item in db.BlogCategory.ToList())
            {
                if (item.BlogCategoryId == Convert.ToInt32(id))
                {
                    ViewData["BlogCategoryName"] = item.BlogCategoryName;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult CategoryEdit(BlogCategory blogCategory)
        {
            foreach (var item in db.BlogCategory.ToList())
            {
                if (item.BlogCategoryId == Convert.ToInt32(TempData["BlogCategoryId"]))
                {
                    if (blogCategory.BlogCategoryName.Length > 0)
                    {
                        item.BlogCategoryName = blogCategory.BlogCategoryName;
                        db.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
            }
            return RedirectToAction("Index");
        }
        ////-------------------------------------------------------------------


        //to upload photos to the database (Blog page)
        public void SavePic(HttpPostedFileBase BlogBackPic, BlogPage blogPage)
        {
            var fileName = BlogBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            BlogBackPic.SaveAs(FilePath);
            blogPage.BlogtBackPic = fileName;
            db.SaveChanges();
        }
        //------------------------------------------------------------------
    }
}