using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "ContactPage")]
    public class ContactPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactBackPic { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactBackPicText { get; set; }

        [Required]
        [MaxLength(150)]
        public string ContactAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactPhone { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactEmail { get; set; }

        [Required]
        public string ContactOfficeLocation { get; set; }

    }
}