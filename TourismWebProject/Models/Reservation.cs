using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Reservations")]
    public class Reservation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationServiceId { get; set; }

        [Required]
        public int ReservationServiceTypeId { get; set; }

        [Required]
        public DateTime ReservationDateFrom { get; set; }

        [Required]
        public DateTime ReservationDateTo { get; set; }

        [Required]
        public int ReservationTotal { get; set; }

        [Required]
        public bool ReservationStatus { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; }

    }
}