using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingExample.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        [InverseProperty("Rooms")]
        public virtual RoomType RoomType { get; set; }
        [InverseProperty(nameof(Reservation.Room))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
