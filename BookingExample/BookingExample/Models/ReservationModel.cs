using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingExample.Models
{
    public class ReservationModel
    {
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
