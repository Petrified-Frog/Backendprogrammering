using System;
using System.Collections.Generic;

#nullable disable

namespace BookingExample.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
