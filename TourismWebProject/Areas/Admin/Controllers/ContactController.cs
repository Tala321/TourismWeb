using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TourismWebProject.Models;
namespace TourismWebProject.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class ContactController : BaseController
    {
        TourismDbContext db = new TourismDbContext();


        // GET: Admin/Contact
        public ActionResult Index()
        {

            ContactViewModel viewModel = new ContactViewModel()
            {
               contactForm = db.ContactForm.ToList(),
                contactPage = db.ContactPage.ToList()
            };
            return View(viewModel);
        }


        //Edit Main Page-------------------------------------------------------------------
        [HttpGet]
        public ActionResult MainEdit(int? id)
        {
            TempData["ContactPageId"] = id;

            foreach (var item in db.ContactPage.ToList())
            {
                if (item.ContactId == Convert.ToInt32(id))
                {
                    ViewData["ContactPageBackPicText"] = item.ContactBackPicText.ToString();
                    ViewData["ContactPageAddress"] = item.ContactAddress.ToString();
                    ViewData["ContactPagePhone"] = item.ContactPhone.ToString();
                    ViewData["ContactPageEmail"] = item.ContactEmail.ToString();
                    ViewData["ContactPageOfficeLocation"] = item.ContactOfficeLocation.ToString();
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MainEdit([Bind(Exclude = "ContactBackPic")] ContactPage contactPage, HttpPostedFileBase ContactBackPic)
        {
            foreach (var item in db.ContactPage.ToList())
            {
                try
                {
                    if (item.ContactId == Convert.ToInt32(TempData["ContactPageId"]))
                    {
                        if (contactPage.ContactBackPicText.Length > 0)
                        {
                            item.ContactBackPicText = contactPage.ContactBackPicText;
                            item.ContactAddress = contactPage.ContactAddress;
                            item.ContactEmail = contactPage.ContactEmail;
                            item.ContactPhone = contactPage.ContactPhone;

                            var dir = Server.MapPath("~\\OfficeLocation");

                            var fileName = "OfficeLocation"  + ".txt";
                            var file = Path.Combine(dir, fileName);

                            StreamWriter tw = new StreamWriter(file);
                            tw.WriteLine(contactPage.ContactOfficeLocation);
                            tw.Close();
                            item.ContactOfficeLocation = fileName;

                        }
                        if (ContactBackPic != null)
                        {
                            SavePic(ContactBackPic, item);
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

        //Contact form------------------------------------------------------------
        [HttpGet]
        public ActionResult ContactForm(int? id)
        {
            TempData["ContactFormId"] = id;

            foreach (var item in db.ContactForm.ToList())
            {
                if (item.ContactFormId == Convert.ToInt32(id))
                {
                    ViewData["Subject"] = item.ContactFormSubject.ToString();
                    ViewData["Message"] = item.ContactFormMessage.ToString();
                    ViewData["Name"] = item.ContactFormName.ToString();
                    ViewData["Email"] = item.ContactFormEmail.ToString();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm([Bind(Exclude = "answer")] ContactForm contactForm, [Bind(Include = "answer")] string answer)
        {
            foreach (var item in db.ContactForm.ToList())
            {
                if (item.ContactFormId == Convert.ToInt32(TempData["ContactFormId"]))
                {
                    SendMail(contactForm.ContactFormEmail.ToString(), contactForm.ContactFormName, contactForm.ContactFormSubject, answer);
                }
            }
            return RedirectToAction("Index");
        }


        //---------------------------------------------------------------------

        //to upload photos to the database -------------------
        public void SavePic(HttpPostedFileBase contactPagePic, ContactPage item)
        {
            var fileName = contactPagePic.FileName;
            var FilePath = Path.Combine(Server.MapPath("~/Assets/Images"), fileName);
            contactPagePic.SaveAs(FilePath);
            item.ContactBackPic = fileName;
            db.SaveChanges();
        }

        // Send mail to user---------------------------------
        public void SendMail(string email, string name, string subject1, string body1)
        {
            //password:movement88
            var fromAddress = new MailAddress("tourismcompanyproject1@gmail.com", "Tourism agency");
            var toAddress = new MailAddress(email, name);
            const string fromPassword = "movement88";
            string subject = subject1;
            string body = body1;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}