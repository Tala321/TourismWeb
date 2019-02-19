using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
       [Table(name: "Tour")]
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourId { get; set; }

        [Required]
        [MaxLength(50)]
        public string TourName { get; set; }

        [Required]
        public int TourPrice { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public string TourDescription { get; set; }

        [Required]
        public int TourCapacity { get; set; }

        [Required]
        public bool TourStatus { get; set; }


        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public int RatingId { get; set; }

        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public ICollection<TourPhoto> TourPhoto { get; set; }
    }
}