using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingExample.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Reservation.PaymentMethod))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
