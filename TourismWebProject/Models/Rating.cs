using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Ratings")]
    public class Rating
    {
        public Rating()
        {

            Hotel = new HashSet<Hotel>();

            Tour = new HashSet<Tour>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RatingStar { get; set; }

        public ICollection<Hotel> Hotel { get; set; }

        public ICollection<Tour> Tour { get; set; }
    }
}