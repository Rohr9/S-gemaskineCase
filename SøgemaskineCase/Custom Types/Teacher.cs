using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SøgemaskineCase.Custom_Types
{
    public class Teacher : Person
    {
        public List<Course> TeacherCourse { get; set; } = new List<Course>();
    }
}
