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
    [Route("api/educations")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly MongoDbContext _mongo;
        public EducationController(MongoDbContext mongo)
        {
            _mongo = mongo;
        }

        [HttpGet]
        public IActionResult Educations()
        {
            var educations = _mongo.Educations.Find(x => true).ToList();
            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult GetEducation(string id)
        {
            var education = _mongo.Educations.Find(x => x.Code == id).FirstOrDefault();
            return new OkResult();
        }

        [HttpPost]
        public IActionResult CreateEducation(CreateEducationModel model)
        {
            var newEducation = new EducationModel() { Length = model.Length, Courses = model.Courses, Classes = model.Classes };
            _mongo.Educations.InsertOne(newEducation);
            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEducation(string id, CreateEducationModel model)
        {
            var upEducation = new EducationModel() { Length = model.Length, Courses = model.Courses, Classes = model.Classes };
            _mongo.Educations.ReplaceOne(x => x.Code == upEducation.Code, upEducation);
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(string id)
        {
            var education = _mongo.Educations.Find(x => x.Code == id).FirstOrDefault();
            _mongo.Educations.DeleteOne(x => x.Code == education.Code);
            return new OkResult();
        }
    }
}
