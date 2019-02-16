using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Locations")]
    public class Location
    {
        public Location()
        {
            Hotel = new HashSet<Hotel>();

            Tour = new HashSet<Tour>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocationCountryName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocationCityName { get; set; }

        public ICollection<Hotel> Hotel { get; set; }

        public ICollection<Tour> Tour { get; set; }

    }
}