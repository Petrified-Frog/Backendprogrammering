using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3_Entityframework_codeFirst.Models
{
    public class Reservation
    {       
        public enum paymentMethods { cash, card, blood};

        [Key]
        public int ReservationNr { get; set; }

        [Required]
        public DateTime CheckinDate { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        [Required]
        [Column(TypeName ="smallint")]
        public paymentMethods PaymentMethod { get; set; }

        [Required]
        [ForeignKey("Room")]       
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
