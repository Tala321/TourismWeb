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
                contactForm = db.ContactForm.Include(x => x.UserId).ToList(),
                contactPage = db.ContactPage.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ContactForm contactForm )
        {
           
            db.ContactForm.Add(contactForm);
            try
            {
                
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
           
            return RedirectToAction("Index");
        }
    }
}