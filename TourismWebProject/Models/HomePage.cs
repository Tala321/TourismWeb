using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"HomePage")]
    public class HomePage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string HomeBackPic { get; set; }

        [Required]
        [MaxLength(50)]
        public string HomeHeading { get; set; }

        [Required]
        [MaxLength(100)]
        public string HomeText { get; set; }

        [Required]
        [MaxLength(50)]
        public string TestimonialHeading { get; set; }

        [Required]
        [MaxLength(250)]
        public string TestimonialText { get; set; }


        [Required]
        [MaxLength(50)]
        public string NewsLetterHeading { get; set; }


        [Required]
        [MaxLength(250)]
        public string NewsLetterText { get; set; }

        [Required]
        [MaxLength(250)]
        public string FactHeading { get; set; }

        [Required]
        [MaxLength(300)]
        public string FactText { get; set; }

    }
}