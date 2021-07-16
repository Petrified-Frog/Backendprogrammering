using Extrauppgift1.Data;
using Extrauppgift1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extrauppgift1.Services
{
    public class MongoService
    {
        private readonly MongoDbContext _context;
        public MongoService(MongoDbContext context)
        {
            _context = context;
        }

        public CourseModel CreateCourse(CreateCourseModel model)
        {
            var newcourse = new CourseModel() { StartDate = model.StartDate, EndDate = model.EndDate, Description = model.Description, Goals = model.Goals };
            _context.Courses.InsertOne(newcourse);
            return new CourseModel
            {
                CourseCode = newcourse.CourseCode,
                StartDate = newcourse.StartDate,
                EndDate = newcourse.EndDate,
                Description = newcourse.Description,
                Goals = newcourse.Goals
            };
        }

    }
}
