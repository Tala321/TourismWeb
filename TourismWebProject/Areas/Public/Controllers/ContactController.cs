using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;

namespace TourismWebProject.Areas.Public.Controllers
{
    public class ContactController : Controller
    {
        TourismDbContext db = new TourismDbContext();

        // GET: Public/Contact
        [HttpGet]
        public ActionResult Index()
        {
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