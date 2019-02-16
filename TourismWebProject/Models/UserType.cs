using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name:"UserTypes")]
    public class UserType
    {
        public UserType()
        {
            ContactForm = new HashSet<ContactForm>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        public ICollection<ContactForm> ContactForm { get; set; }

    }
}