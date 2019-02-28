using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class HotelRoom
    {


        [Key, Column(Order = 0)]
        public int HotelId { get; set; }

        [Key, Column(Order = 1)]
        public int RoomId { get; set; }

        [Required]
        public int Status { get; set; }

        public Hotel hotel { get; set; }
        public Room room { get; set; }
  
    }
}