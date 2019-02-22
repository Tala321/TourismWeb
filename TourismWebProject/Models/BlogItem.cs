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
            Tag = new HashSet<Tag>();

            BlogCategory = new HashSet<BlogCategory>();

            BlogDetail = new HashSet<BlogDetail>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BlogItemSource { get; set; }


        public int AdminId { get; set; }

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        public ICollection<Tag> Tag { get; set; }

        public ICollection<BlogCategory> BlogCategory { get; set; }

        public ICollection<BlogDetail> BlogDetail { get; set; }

    }
}