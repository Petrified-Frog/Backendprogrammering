using System;
using System.Collections.Generic;

#nullable disable

namespace BookingExample.Models
{
    public partial class Guest
    {
        public Guest()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
