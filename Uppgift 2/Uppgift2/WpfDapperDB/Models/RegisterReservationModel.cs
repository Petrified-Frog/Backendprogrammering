using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDapperDB.Models
{
    public class RegisterReservationModel
    {
        public int RoomNr { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int paymentMethod { get; set; }
    }
}
