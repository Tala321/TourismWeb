using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;


namespace TourismWebProject.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly TourismDbContext db;

        public AccountController()
        {
            db = new TourismDbContext();
        }
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var admin = db.Admin.FirstOrDefault(a => a.AdminEmail == loginModel.Email);

            if(admin==null)
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel);
            }

            if (admin.AdminPassword != loginModel.Password)
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel);
            }

            Session["adminLog"] = true;
            return RedirectToAction("Index","Home");
        }


        public ActionResult Logout()
        {
            Session["adminLog"] = null;
            return RedirectToAction("Login");
        }
    }
}