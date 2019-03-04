using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class HomeViewModel
    {
        public List<HomePage> HomePage { get; set; }

        public List<BlogItem> BlogItem { get; set; }

        public List<Comment> Comment { get; set; }

        public List<Hotel> Hotel { get; set; }

        public List<Tour> Tour { get; set; }


    }
}