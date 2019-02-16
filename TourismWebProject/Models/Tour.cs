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

       
        public Location LocationId { get; set; }

       
        public Rating RatingId { get; set; }

        
        public ServiceType ServiceTypeId { get; set; }

        [Required]
        public Hotel HotelId { get; set; }


        public ICollection<TourPhoto> TourPhoto { get; set; }
    }
}