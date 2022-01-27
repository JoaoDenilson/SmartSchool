using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class StudentCourse
    {
        public StudentCourse() { }
        public StudentCourse(int studentId, int courseId)
        {
            this.StudentId = studentId;
            this.CourseId = courseId;
        }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
