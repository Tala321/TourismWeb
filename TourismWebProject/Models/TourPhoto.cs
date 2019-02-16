using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "TourPhotos")]
    public class TourPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourPhotoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TourPhotoName { get; set; }

        public ICollection<Tour> Tour { get; set; }
    }
}