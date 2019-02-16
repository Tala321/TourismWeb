using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Tags")]
    public class Tag
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TagName { get; set; }

        public ICollection<BlogItem> BlogItem { get; set; }
    }
}