﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "CommentTypes")]
    public class CommentType
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CommentTypeName { get; set; }

     

    }
}