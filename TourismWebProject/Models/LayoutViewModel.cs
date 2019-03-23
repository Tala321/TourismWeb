using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class LayoutViewModel
    {
        public List<MainMenu> MainMenu { get; set; }

        public List<ContactPage> ContactPage { get; set; }

        public List<User> User { get; set; }

        public List<Admin> Admin { get; set; }

    }
}