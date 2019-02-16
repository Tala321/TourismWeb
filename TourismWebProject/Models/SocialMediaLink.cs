using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"SocialMediaLinks")]
    public class SocialMediaLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SocialMediaLinkId { get; set; }

        [Required]
        [MaxLength(200)]
        public string SocialMediaLinkName { get; set; }
    }
}