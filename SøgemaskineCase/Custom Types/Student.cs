using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SøgemaskineCase.Custom_Types
{
    public class Student : Person
    {
        public List<Course> StudentCourse { get; set; } = new List<Course>();
    }
}
