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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int BlogItemId { get; set; }

        [ForeignKey("BlogItemId")]
        public BlogItem BlogItem { get; set; }

    }
}