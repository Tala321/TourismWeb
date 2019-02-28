using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class HotelViewModel
    {
        public List<Hotel> Hotel { get; set; }

        public List<HotelPage> HotelPage { get; set; }

        public List<Room> Room { get; set; }

        public List<HotelRoom> HotelRoom { get; set; }

    }
}