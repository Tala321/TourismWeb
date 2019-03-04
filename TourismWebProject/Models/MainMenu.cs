using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "MainMenus")]
    public class MainMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainMenuId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public  string MainMenuName { get; set; }


        [Required]
        public int MainMenuOrder { get; set; }
    }
}