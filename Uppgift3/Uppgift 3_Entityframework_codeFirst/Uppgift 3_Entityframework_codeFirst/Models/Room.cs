using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_3_Entityframework_codeFirst.Models
{
    public class Room
    {
        public enum roomTypes { single, @double, luxury};

        public int ID { get; set; }
        [Required]
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Required]
        [Column(TypeName ="smallint")]
        public roomTypes RoomType { get; set; }

    }
}
