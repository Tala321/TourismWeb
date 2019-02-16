using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "AboutItems")]
    public class AboutItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AboutHeading { get; set; }

        [Required]
        [MaxLength(100)]
        public string AboutSubHeading { get; set; }

        [Required]
        public string AboutText { get; set; }
    }
}