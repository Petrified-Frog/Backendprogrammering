using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3_Entityframework_codeFirst.Models
{
    public class Guest
    {
        public Guest()
        {
            this.Reservations = new List<Reservation>();
        }

        public int ID {get;set;}
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]       
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationNr { get; set; }
        public List< Reservation> Reservations { get; set; }


    }
}
