using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlClientDB
{
    public enum paymentMethods { card, swish, cash }
    class Reservation
    {        
        public int reservationNr { get; set; }
        public int roomNr { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public paymentMethods paymentType { get; set; }

    }
}
