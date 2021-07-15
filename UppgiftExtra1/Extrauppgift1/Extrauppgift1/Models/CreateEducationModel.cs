using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extrauppgift1.Models
{
    public class CreateEducationModel
    {
        public DateTime Length { get; set; }
        public List<CourseModel> Courses { get; set; }
        public List<ClassModel> Classes { get; set; }
    }
}
