using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{

    [Table(name: "Facts")]
    public class Fact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FactName { get; set; }

        [Required]
        public int FactAmount { get; set; }
    }
}