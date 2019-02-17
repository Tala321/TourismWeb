using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
namespace TourismWebProject.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Admin/About
        public ActionResult Index()
        {
            AboutViewModel viewModel = new AboutViewModel()
            {
                AboutPage = db.AboutPage.ToList(),
                AboutItem = db.AboutItem.ToList()
            };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["AboutPageId"] = id;

            foreach (var item in db.AboutPage.ToList())
            {
                if (item.AboutPageId == Convert.ToInt32(id))
                {
                    ViewData["AboutPageBackPicText"] = item.AboutPageBackPicText.ToString();
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult MainEdit([Bind(Exclude = "AboutPageBackPic,AboutPagePic")] AboutPage aboutPage, HttpPostedFileBase AboutPageBackPic, HttpPostedFileBase AboutPagePic)
        {
            foreach (var item in db.AboutPage.ToList())
            {
                try
                {
                    if (item.AboutPageId == Convert.ToInt32(TempData["AboutPageId"]))
                    {
                        if (aboutPage.AboutPageBackPicText.Length > 0)
                        {
                            item.AboutPageBackPicText = aboutPage.AboutPageBackPicText;
                        }
                        if (AboutPageBackPic != null)
                        {
                            SavePic(1, AboutPageBackPic, item);
                        }
                        if (AboutPagePic != null)
                        {
                            SavePic(2, AboutPagePic, item);
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

        [HttpGet]
        public ActionResult ItemEdit(int? id)
        {
            TempData["AboutId"] = id;

            foreach (var item in db.AboutItem.ToList())
            {
                if (item.AboutId == Convert.ToInt32(id))
                {
                    ViewData["AboutHeading"] = item.AboutHeading.ToString();

                    ViewData["AboutSubHeading"] = item.AboutSubHeading.ToString();

                    ViewData["AboutText"] = item.AboutText.ToString();
                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult ItemEdit(AboutItem aboutItem)
        {

            foreach (var item in db.AboutItem.ToList())
            {
                try
                {
                    if (item.AboutId == Convert.ToInt32(TempData["AboutId"]))
                    {
                        if (aboutItem.AboutHeading.Length > 0)
                        {
                            item.AboutHeading = aboutItem.AboutHeading;
                        }

                        if (aboutItem.AboutSubHeading.Length > 0)
                        {
                            item.AboutSubHeading = aboutItem.AboutSubHeading;
                        }

                        if (aboutItem.AboutText.Length > 0)
                        {
                            item.AboutText = aboutItem.AboutText;
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


        //to upload photos to the database (Main part of about page)
        public void SavePic(int num, HttpPostedFileBase aboutPagePic, AboutPage item)
        {
            var fileName = aboutPagePic.FileName;
            var Extension = Path.GetExtension(fileName);
            var File = fileName;
            var FilePath = Path.Combine(Server.MapPath("~/Images"), File);
            aboutPagePic.SaveAs(FilePath);
            if (num == 1)
            {
                item.AboutPageBackPic = File;
            }
            else
            {
                item.AboutPagePic = File;
            }

            db.SaveChanges();
        }
    }
}