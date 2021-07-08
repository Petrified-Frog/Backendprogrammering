using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQLMongo.Models
{
    public class CreateReservationModel
    {
        public paymentMethods PaymentMethod { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string RoomNr { get; set; }
        public string GuestId { get; set; }
    }
}
