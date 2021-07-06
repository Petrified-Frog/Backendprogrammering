using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3_Entityframework_codeFirst.Models
{
    public class GuestReservation
    {
        [Key, Column(Order =1)]
        [ForeignKey("Guest")]
        public int GuestID { get; set; }

        [Key, Column(Order =0)]
        [ForeignKey("Reservation")]
        public int ReservationNr { get; set; }
    }
}
