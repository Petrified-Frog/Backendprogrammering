using Extrauppgift1.Data;
using Extrauppgift1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extrauppgift1.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly MongoDbContext _context;
        public CoursesController(MongoDbContext mongo)
        {
            _context = mongo;
        }

        [HttpGet]
        public IActionResult Courses()
        {
            var courses= _context.Courses.Find(x => true).ToList();
            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(string id)
        {
            var course = _context.Courses.Find(x => x.CourseCode == id).FirstOrDefault();
            return new OkResult();
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseModel model)
        {
            var newcourse = new CourseModel() { StartDate = model.StartDate, EndDate = model.EndDate, Description = model.Description, Goals = model.Goals };
            _context.Courses.InsertOne(newcourse);
            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(string id, CreateCourseModel model)
        {
            var upcourse = new CourseModel() { StartDate = model.StartDate, EndDate = model.EndDate, Description = model.Description, Goals = model.Goals };
            _context.Courses.ReplaceOne(x => x.CourseCode == id, upcourse);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(string id)
        {
            var course = _context.Courses.Find(x => x.CourseCode == id).FirstOrDefault();
            _context.Courses.DeleteOne(x => x.CourseCode == course.CourseCode);
            return new OkResult();
        }
    }
}
