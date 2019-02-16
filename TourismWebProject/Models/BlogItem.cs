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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogItemTitle { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogItemPic { get; set; }

        [Required]
        public string BlogItemText { get; set; }

        [Required]
        [MaxLength(50)]
        public string BlogItemAuthor { get; set; }

        [Required]
        public DateTime BlogItemDate { get; set; }

        [Required]
        public Admin AdminId { get; set; }

        public ICollection<Tag> Tag { get; set; }

        public ICollection<BlogCategory> BlogCategory { get; set; }

        public ICollection<BlogDetail> BlogDetail { get; set; }

    }
}