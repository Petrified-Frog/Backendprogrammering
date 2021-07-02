using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingExample.Models
{
    public partial class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public int PaymentMethodId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(GuestId))]
        [InverseProperty("Reservations")]
        public virtual Guest Guest { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("Reservations")]
        public virtual PaymentMethod PaymentMethod { get; set; }
        [ForeignKey(nameof(RoomId))]
        [InverseProperty("Reservations")]
        public virtual Room Room { get; set; }
    }
}
