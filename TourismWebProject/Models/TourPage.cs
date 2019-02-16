using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "TourPage")]
    public class TourPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToursPageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ToursPageBackPic { get; set; }

        [Required]
        [MaxLength(50)]
        public string ToursPageBackPicText { get; set; }

    }
}