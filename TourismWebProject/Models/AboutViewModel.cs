using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TourismWebProject.Models;
namespace TourismWebProject.Models
{
    public class AboutViewModel
    {
        public List<AboutPage> AboutPage { get; set; }

        public List<AboutItem> AboutItem { get; set; }

        public List<Faq> Faqs { get; set; }

    }
}