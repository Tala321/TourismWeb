using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class ContactViewModel
    {
        public List<ContactPage> contactPage { get; set; }

        public List<ContactForm> contactForm { get; set; }
    }
}