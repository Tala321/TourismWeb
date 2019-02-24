using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"BlogItems")]
    public class BlogItem
    {
        public BlogItem()
        {
            Comment = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogItemSource { get; set; }


        [Required]
        [MaxLength(100)]
        public string BlogItemTitle { get; set; }


        [Required]
        [MaxLength(100)]
        public string BlogItemCover { get; set; }

        [Required]
        [MaxLength(150)]
        public string BlogItemAuthor { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int AdminId { get; set; }

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        public int BlogCategoryId { get; set; }

        [ForeignKey("BlogCategoryId")]
        public BlogCategory BlogCategory { get; set; }

        public ICollection<Comment> Comment { get; set; }

    }
}