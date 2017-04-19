using System;
using System.Collections.Generic;

namespace EntityAndSql.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
