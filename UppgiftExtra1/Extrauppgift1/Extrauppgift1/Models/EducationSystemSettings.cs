using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extrauppgift1.Models
{
    public interface IEducationSystemSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ClassCollectionName { get; set; }
        string EducationCollectionName { get; set; }
        string CourseCollectionName { get; set; }
        string EducationCourseCollection { get; set; }

    }

    public class EducationSystemSettings : IEducationSystemSettings
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ClassCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EducationCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CourseCollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EducationCourseCollection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
