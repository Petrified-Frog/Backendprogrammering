﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BookingExample.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
