using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"ContactForms")]
    public class ContactForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactFormId { get; set; }

        [Required]
        [MaxLength(60)]
        public string ContactFormName { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactFormEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactFormSubject { get; set; }

        [Required]
        public string ContactFormMessage { get; set; }

        [Required]
        public User UserId { get; set; }


    }
}