using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
using System.IO;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ContactController : BaseController
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Contact
        [HttpGet]
        public ActionResult Index()
        {
            var dir = Server.MapPath("~\\OfficeLocation");
            var file = Path.Combine(dir, db.ContactPage.First().ContactOfficeLocation);
            var fileContent = System.IO.File.ReadAllText(file);
            ViewData["Location"] = fileContent;

            ContactViewModel viewModel = new ContactViewModel()
            {
                contactForm = db.ContactForm.ToList(),
                contactPage = db.ContactPage.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ContactForm contactForm )
        {
           
            db.ContactForm.Add(contactForm);
             
                db.SaveChanges();
         
            return RedirectToAction("Index");
        }
    }
}