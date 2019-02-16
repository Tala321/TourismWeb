using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Faqs")]
    public class Faq
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FaqId { get; set; }

        [Required]
        [MaxLength(200)]
        public string FaqQuestion { get; set; }

        [Required]
        public string FaqAnswer { get; set; }
    }
}