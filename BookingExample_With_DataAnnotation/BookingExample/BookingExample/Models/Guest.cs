using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingExample.Models
{
    [Index(nameof(Email), Name = "UQ__Guests__A9D1053493C344F3", IsUnique = true)]
    public partial class Guest
    {
        public Guest()
        {
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [InverseProperty(nameof(Reservation.Guest))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
