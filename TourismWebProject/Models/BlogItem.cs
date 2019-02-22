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
        public string BlogItemSource { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int AdminId { get; set; }

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

      public ICollection<BlogCategory> BlogCategory { get; set; }

    }
}