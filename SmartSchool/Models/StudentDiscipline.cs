using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class StudentDiscipline
    {
        public StudentDiscipline() { }
        public StudentDiscipline(int studentId, int disciplineId)
        {
            this.StudentId = studentId;
            this.DisciplineId = disciplineId;
        }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; }
        public int? FinalGrade { get; set; } = null;
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
