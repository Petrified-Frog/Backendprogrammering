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
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly MongoDbContext _mongo;
        public ClassesController(MongoDbContext mongo)
        {
            _mongo = mongo;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            var classes = _mongo.Classes.Find(x => true).ToList();
            return new OkResult();
        }

        [HttpGet("{id}")]
        public IActionResult GetClass(string id)
        {
            var eclass = _mongo.Classes.Find(x => x.Id == id).FirstOrDefault();
            return new OkResult();
        }

        [HttpPost]
        public IActionResult CreateClass(CreateClassModel model)
        {
            var mongoClass = new ClassModel() { pupilIds = model.pupilIds };
            _mongo.Classes.InsertOne(mongoClass);
            return new OkResult();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClass(string id, ClassModel model)
        {
            var mongoClass = new ClassModel() { pupilIds = model.pupilIds };
            _mongo.Classes.ReplaceOne(x => x.Id == id, mongoClass) ;
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(string id)
        {
            var mongoClass = _mongo.Classes.Find(x => x.Id == id).FirstOrDefault();
            _mongo.Classes.DeleteOne(x => x.Id == mongoClass.Id);
            return new OkResult();
        }
        
    }
}
