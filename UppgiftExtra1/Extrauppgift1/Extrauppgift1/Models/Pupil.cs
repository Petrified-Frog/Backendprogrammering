using System;
using System.Collections.Generic;

#nullable disable

namespace Extrauppgift1.Models
{
    public partial class Pupil
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastNamr { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AdOk { get; set; }
        public string ProfileImgUrl { get; set; }
        public int? ClassId { get; set; }
    }
}
