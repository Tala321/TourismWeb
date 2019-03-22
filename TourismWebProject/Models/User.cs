using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Users")]
    public class User : IdentityUser
    {
        public User()
        {
            Reservation = new HashSet<Reservation>();

            Comment = new HashSet<Comment>();

            ContactForm = new HashSet<ContactForm>();

            TourList = new HashSet<TourList>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserSurname { get; set; }


        [MaxLength(100)]
        public string UserPic { get; set; }


        [MaxLength(50)]
        public string UserPhone { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserEmail { get; set; }

        [MaxLength(300)]
        public string UserInfo { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserCountry { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserPassword { get; set; }

        public ICollection<Reservation> Reservation { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public ICollection<ContactForm> ContactForm { get; set; }

        public ICollection<TourList> TourList { get; set; }

    }
}