using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Hotels")]
    public class Hotel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string HotelName { get; set; }

        [Required]
        [MaxLength(100)]
        public string HotelAddress { get; set; }


        [Required]
        public string HotelDescription { get; set; }


        [Required]
        public string HotelCountry { get; set; }

        [Required]
        public string HotelCity { get; set; }

        [Required]
        public string HotelPic { get; set; }


        [Required]
        public string HotelCoverPic { get; set; }

        [Required]
        public int HotelStatus { get; set; }


        public int RatingId { get; set; }

        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; }

        public ICollection<Room> Room { get; set; }

        public ICollection<HotelPhoto> HotelPhoto { get; set; }
    }
}