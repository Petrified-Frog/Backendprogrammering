using System;
using System.Collections.Generic;

#nullable disable

namespace BookingExample.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Room Room { get; set; }
    }
}
