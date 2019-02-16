using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "BlogCategories")]
    public class BlogCategory
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogItemTitle { get; set; }

        public ICollection<BlogItem> BlogItem { get; set; }
    }
}