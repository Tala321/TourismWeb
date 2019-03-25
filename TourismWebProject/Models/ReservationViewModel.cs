using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class ReservationViewModel
    {
        public List<Reservation> reservation { get; set; }

        public List<TourList> tourList { get; set; }

    }
}