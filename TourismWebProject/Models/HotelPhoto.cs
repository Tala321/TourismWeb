using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "HotelPhotos")]
    public class HotelPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelPhotoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string HotePhotolName { get; set; }

        public ICollection<Hotel> Hotel { get; set; }

    }
}