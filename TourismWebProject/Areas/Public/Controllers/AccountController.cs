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
    public class AccountController : Controller
    {
        private readonly TourismDbContext db;

        public AccountController()
        {
            db = new TourismDbContext();
        }

        // GET: Public/Account

        //login----------------------------------
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var user = db.User.FirstOrDefault(a => a.UserEmail == loginModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel);
            }

            if (user.UserPassword != loginModel.Password)
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel);
            }

            Session["UserLog"] = user.UserId;
            return RedirectToAction("Index", "Home");
        }

        //---------------------------------------------------

        //logout---------------------------------------
        public ActionResult Logout()
        {
            Session["UserLog"] = null;
            return RedirectToAction("Index", "Home");
        }
        //-------------------------------

        //profile-------------------------------
        public ActionResult YourProfile()
        {
            //to show edit panel
            ViewData["Check"] = TempData["Check"];
            ViewData["UserName"] = TempData["UserName"];
            ViewData["UserSurname"] = TempData["UserSurname"];
            ViewData["UserPhone"] = TempData["UserPhone"];
            ViewData["UserEmail"] = TempData["UserEmail"];
            ViewData["UserInfo"] = TempData["UserInfo"];

            var id = Convert.ToInt32(Session["UserLog"]);

            if (Session["UserLog"] == null)
            {
                return RedirectToAction("Login");
            }

            ViewData["Reservations"] = db.Reservation.Include(x => x.ServiceType).ToList();
            ViewData["Hotels"] = db.Hotel.Include(x => x.HotelRoom).ToList();
            ViewData["Rooms"] = db.Room.ToList();
            ViewData["TourList"] = db.TourList.Include(g => g.User).Include(x => x.Tour).ToList();
            return View(db.User.Where(i => i.UserId == id).ToList());
        }


        public ActionResult UploadPhoto([Bind(Exclude = "UserPic")]User user, HttpPostedFileBase UserPic)
        {
            if (UserPic != null)
            {
                SavePic(UserPic, Convert.ToInt32(Session["UserLog"]));
            }

            return RedirectToAction("YourProfile");
        }


        [HttpGet]
        public ActionResult EditInfo()
        {
            //show data to user 
            TempData["Check"] = 1;

            foreach (var item in db.User.ToList())
            {
                if (item.UserId == Convert.ToInt32(Session["UserLog"]))
                {
                    TempData["UserName"] = item.UserName;
                    TempData["UserSurname"] = item.UserSurname;
                    TempData["UserPhone"] = item.UserPhone;
                    TempData["UserEmail"] = item.UserEmail;
                    TempData["UserInfo"] = item.UserInfo;
                }
            }

            return RedirectToAction("YourProfile");
        }

        [HttpPost]
        public ActionResult EditInfo(User user)
        {
            if(user.UserName !=null && user.UserSurname !=null && user.UserPhone !=null && user.UserEmail !=null&& user.UserInfo !=null)
            {
                foreach (var item in db.User.ToList())
                {
                    if (item.UserId == Convert.ToInt32(Session["UserLog"]))
                    {
                        item.UserName = user.UserName;
                        item.UserSurname = user.UserSurname;
                        item.UserPhone = user.UserPhone;
                        item.UserEmail = user.UserEmail;
                        item.UserInfo = user.UserInfo;
                        db.SaveChanges();
                    }
                }
            }
           
            return RedirectToAction("YourProfile");
        }
        //-------------------------


        //Upload photo
        public void SavePic(HttpPostedFileBase Pic, int id)
        {
            var fileName = Pic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            Pic.SaveAs(FilePath);
            var user = db.User.FirstOrDefault(i => i.UserId == id);
            user.UserPic = fileName;
            db.SaveChanges();
        }
    }
}