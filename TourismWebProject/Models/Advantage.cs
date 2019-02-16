using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Advantages")]
    public class Advantage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvantageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdvantageHeading { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdvantageText { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdvantagePic { get; set; }

    }
}