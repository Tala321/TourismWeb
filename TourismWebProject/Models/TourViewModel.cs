using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class TourViewModel
    {
        public List<Tour> Tour { get; set; }

        public List<TourPage> TourPage { get; set; }
    }
}