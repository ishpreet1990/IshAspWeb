
using System;
using System.Collections.Generic;

namespace EntityAndSql.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public decimal Scores { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
