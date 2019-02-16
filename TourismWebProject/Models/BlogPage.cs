using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "BlogPage")]
    public class BlogPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogtBackPic { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogBackPicText { get; set; }
    }
}