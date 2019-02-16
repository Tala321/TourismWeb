using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Comments")]
    public class Comment
    {

        public CommentType CommentTypeId { get; set; }

        public ServiceType ServiceTypeId { get; set; }

        public User UserId { get; set; }

    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }


    }
}