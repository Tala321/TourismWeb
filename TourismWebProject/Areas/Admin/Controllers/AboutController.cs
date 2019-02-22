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
                AboutItem = db.AboutItem.ToList(),
                Faqs = db.Faq.ToList()
            };

            return View(viewModel);
        }

        //Edit Main Page-------------------------------------------------------------------
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
        //------------------------------------------------------------------

        //Edit items-------------------------------------------------------------------
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
        //------------------------------------------------------------------


        //Edit Faq-------------------------------------------------------------------
        [HttpGet]
        public ActionResult FaqEdit(int? id)
        {
            TempData["FaqId"] = id;

            foreach (var item in db.Faq.ToList())
            {
                if (item.FaqId == Convert.ToInt32(id))
                {
                    ViewData["FaqQuestion"] = item.FaqQuestion.ToString();

                    ViewData["FaqAnswer"] = item.FaqAnswer.ToString();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult FaqEdit(Faq faq)
        {
            foreach (var item in db.Faq.ToList())
            {
                try
                {
                    if (item.FaqId == Convert.ToInt32(TempData["FaqId"]))
                    {
                        if (faq.FaqQuestion.Length > 0)
                        {
                            item.FaqQuestion = faq.FaqQuestion;
                        }
                        if (faq.FaqAnswer.Length > 0)
                        {
                            item.FaqAnswer = faq.FaqAnswer;
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

        //------------------------------------------------------------------

        //Create,Delete Faq-------------------------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Faq NewFaq)
        {
            try
            {
                db.Faq.Add(NewFaq);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult FaqDelete(int? id)
        {
            foreach (var item in db.Faq.ToList())
            {
                if (item.FaqId == Convert.ToInt32(id))
                {
                    db.Faq.Remove(item);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //to upload photos to the database 
        public void SavePic(int num, HttpPostedFileBase aboutPagePic, AboutPage item)
        {
            var fileName = aboutPagePic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            aboutPagePic.SaveAs(FilePath);
            if (num == 1)
            {
                item.AboutPageBackPic = fileName;
            }
            else
            {
                item.AboutPagePic = fileName;
            }

            db.SaveChanges();
        }
        //------------------------------------------------------------------
    }
}