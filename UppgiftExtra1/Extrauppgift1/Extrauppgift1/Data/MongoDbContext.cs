using Extrauppgift1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extrauppgift1.Data
{
    public class MongoDbContext
    {
        public MongoDbContext()
        {            
            var client = new MongoClient(@"mongodb+srv://Moln:bytmig123@cluster0.sxi3g.mongodb.net/EducationSystem?retryWrites=true&w=majority");
            var database = client.GetDatabase("EducationSystem");
            var Courses = database.GetCollection<CourseModel>("Courses");
            var Classes = database.GetCollection<ClassModel>("Classes");
            var Educations = database.GetCollection<EducationModel>("Educations");
            var CourseModels = database.GetCollection<EducationCourseModel>("EducationCourseModels");
        }

        public readonly IMongoCollection<CourseModel> Courses;
        public readonly IMongoCollection<ClassModel> Classes;
        public readonly IMongoCollection<EducationModel> Educations;
        public readonly IMongoCollection<EducationCourseModel> EducationCourseModels;
    }
}
