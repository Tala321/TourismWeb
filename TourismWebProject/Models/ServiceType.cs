using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "ServiceTypes")]
    public class ServiceType
    {
        public ServiceType()
        {
            Hotel = new HashSet<Hotel>();

            Tour = new HashSet<Tour>();

            Reservation = new HashSet<Reservation>();

            Comment = new HashSet<Comment>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ServiceTypeName { get; set; }


        public ICollection<Hotel> Hotel { get; set; }

        public ICollection<Tour> Tour { get; set; }

        public ICollection<Reservation> Reservation { get; set; }

        public ICollection<Comment> Comment { get; set; }
    }
}