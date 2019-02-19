using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "BlogDetails")]
    public class BlogDetail
    {
  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogDetailId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BlogDetailTitle { get; set; }

        [Required]
        public string BlogDetailText { get; set; }


        [MaxLength(100)]
        public string BlogDetailPic { get; set; }

        public ICollection<BlogItem> BlogItem { get; set; }
    }

}