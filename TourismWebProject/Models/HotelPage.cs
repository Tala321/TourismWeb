using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{

    [Table(name: "HotelPage")]
    public class HotelPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelPageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string HotelPageBackPic { get; set; }

        [Required]
        [MaxLength(100)]
        public string HotelPageBackPicText { get; set; }

    }
}