using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class RegisterController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Register
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Exclude = "UserPic")]User user, HttpPostedFileBase UserPic)
        {
            if (!db.User.Any(i=>i.UserEmail== user.UserEmail))
            {
                if (user.UserPassword.Count() >= 8)
                {
                    if (ModelState.IsValid)
                    {
                        if(UserPic.ContentLength>0)
                        {
                            SavePic(UserPic, user);
                        }

                        db.User.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Login", "Account");
                    }
                }
            }
            return View();
        }

        //save pic
        public void SavePic(HttpPostedFileBase Pic, User user)
        {
            var fileName = Pic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            Pic.SaveAs(FilePath);
            user.UserPic = fileName;
            db.SaveChanges();
        }
        //------------------------------------------------------------------
    }
}