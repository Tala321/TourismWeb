using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class HomeController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/Home
        public ActionResult Index()
        {         
            return View(db.HomePage.ToList());
        }

        //Edit Main Page-------------------------------------------------------------------
        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["HomePageId"] = id;

            foreach (var item in db.HomePage.ToList())
            {
                if (item.HomeId == Convert.ToInt32(id))
                {
                    ViewData["HomeHeading"] = item.HomeHeading;
                    ViewData["HomeText"] = item.HomeText;
                    ViewData["TestimonialHeading"] = item.TestimonialHeading;
                    ViewData["TestimonialText"] = item.TestimonialText;
                    ViewData["NewsLetterHeading"] = item.NewsLetterHeading;
                    ViewData["NewsLetterText"] = item.NewsLetterText;
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult MainEdit([Bind(Exclude = "HomeBackPic")]HomePage homePage, HttpPostedFileBase HomeBackPic)
        {
            foreach (var item in db.HomePage.ToList())
            {
                try
                {
                    if (item.HomeId == Convert.ToInt32(TempData["HomePageId"]))
                    {                           
                        if (HomeBackPic != null)
                        {
                          SavePic(HomeBackPic, item);
                        }
                        item.HomeText = homePage.HomeText;
                        item.HomeHeading = homePage.HomeHeading;
                        item.TestimonialHeading = homePage.TestimonialHeading;
                        item.TestimonialText = homePage.TestimonialText;
                        item.NewsLetterHeading = homePage.NewsLetterHeading;
                        item.NewsLetterText = homePage.NewsLetterText;
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
        //------------------------------

        //to upload photos to the database 

        //Hotel Page
        public void SavePic(HttpPostedFileBase HomeBackPic, HomePage homePage)
        {
            var fileName = HomeBackPic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            HomeBackPic.SaveAs(FilePath);
            homePage.HomeBackPic = fileName;
            db.SaveChanges();
        }
    }
}