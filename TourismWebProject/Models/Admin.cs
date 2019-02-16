using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"Admins")]
    public class Admin
    {
        public Admin()
        {
            BlogItem = new HashSet<BlogItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdminName { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdminSurname { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdminEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdminPassword { get; set; }

        public ICollection<BlogItem> BlogItem { get; set; }
    }
}