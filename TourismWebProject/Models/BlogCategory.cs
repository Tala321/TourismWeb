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
        public int BlogCategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogCategoryName { get; set; }

        public ICollection<BlogItem> BlogItem { get; set; }
    }
}