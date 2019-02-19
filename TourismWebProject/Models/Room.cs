using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    [Table(name: "Rooms")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int   RoomId { get; set; }

        [Required]
        [MaxLength(50)]
        public string   RoomName { get; set; }

        [Required]
        public int   RoomPrice { get; set; }


        [Required]
        public int   RoomCapacity { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoomPic{ get; set; }

        [Required]
        public string   RoomDescription { get; set; }


        [Required]
        public bool   RoomStatus { get; set; }

        public ICollection<Hotel> Hotel { get; set; }


    }
}