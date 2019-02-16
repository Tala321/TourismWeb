using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "AboutPage")]
    public class AboutPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutPageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AboutPageBackPic { get; set; }

        [Required]
        [MaxLength(100)]
        public string AboutPageBackPicText { get; set; }

        [Required]
        [MaxLength(100)]
        public string AboutPagePic { get; set; }
    }
}